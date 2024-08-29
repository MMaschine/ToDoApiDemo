using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace ToDoApp.DataAccess.Infrastructure;

/// <summary>
/// Infrastructure to init DB context in design time
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDoContext>
{
    public ToDoContext CreateDbContext(string[] args)
    {
        //TODO: for the real app re-write to get values from appsettings.json file and EnvVars 

        var connectionString = "There were my connection string";

        var optionsBuilder = new DbContextOptionsBuilder<ToDoContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ToDoContext(optionsBuilder.Options);
    }
}