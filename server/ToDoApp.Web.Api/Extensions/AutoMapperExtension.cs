using AutoMapper;
using ToDoApp.Web.Api.Mappings;

namespace ToDoApp.Web.Api.Extensions
{
    public static class AutoMapperExtension
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            var configMap = new MapperConfiguration(e =>
            {
                e.AddProfile(new MappingProfile());
            });

            configMap.AssertConfigurationIsValid();
            var mapper = configMap.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
