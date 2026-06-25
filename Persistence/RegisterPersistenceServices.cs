using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            // Register the DbContext with the connection string from configuration
            services.AddDbContext<DCMSDBContext>(options =>
                options.UseSqlServer("DCMSConnectionString"));

            // Register other persistence-related services here if needed

            return services;
        }
    }
}
