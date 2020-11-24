using GT.Domain.Repositories;
using GT.Domain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GT.Web.Api.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            // Singletons

            // Repositories
            services.AddScoped<IGardenRepository, GardenRepository>();
            services.AddScoped<ICropRepository, CropRepository>();

            // Services
            
        }
    }
}