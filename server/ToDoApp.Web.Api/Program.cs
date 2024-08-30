using ToDoApp.DataAccess.DataSources;
using ToDoApp.DataAccess.DataSources.Interfaces;
using ToDoApp.DataAccess.Extensions;
using ToDoApp.Logic.Interfaces;
using ToDoApp.Logic.Services;
using ToDoApp.Web.Api.Extensions;
using ToDoApp.Web.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register automapper
builder.Services.RegisterAutoMapper();

//Configure DB connection
builder.Services.ConfigureDbContext(builder.Configuration.GetConnectionString("ToDoDatabase"));

//Register dependencies

//DA
builder.Services.AddScoped(typeof(IGenericDataSource<>), typeof(GenericDataSource<>));

//Logic
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IToDoTaskService, ToDoTaskService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorsInterceptor>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.DoMigrate(args).Run();
