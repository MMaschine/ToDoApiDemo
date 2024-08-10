using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoApp.DataAccess.Extensions
{
    /// <summary>
    /// Extension to configure DB context 
    /// </summary>
    public static class DbConfigurationExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<ToDoContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
