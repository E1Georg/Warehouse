using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.Interfaces;


namespace Warehouse.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<WarehouseDbContext>(options => {
                options.UseSqlServer(connectionString);              
            });

            services.AddScoped<IWarehouseDbContext>(provider => provider.GetService<WarehouseDbContext>());

            return services;
        }
    }
}
