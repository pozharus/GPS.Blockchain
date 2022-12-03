using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Blockchain.Application.Infrastructure;

namespace Blockchain.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
    services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TrackerPointDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<ITrackerPointDbContext>(provider =>
                provider.GetService<TrackerPointDbContext>());
            return services;
        }
    }
}
