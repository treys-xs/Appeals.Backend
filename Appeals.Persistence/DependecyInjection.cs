using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Appeals.Application.Interfaces;

namespace Appeals.Persistence
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AppealsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<IAppealsDbContext>(provider =>
                provider.GetService<AppealsDbContext>());
            
            return services;
        }   
    }
}
