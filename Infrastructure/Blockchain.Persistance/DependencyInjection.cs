using Blockchain.Application.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Blockchain.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<ITrackerPointDbContext, TrackerPointDbContext>();
            return services;
        }
    }
}
