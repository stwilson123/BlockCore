using BlocksCore.ResourcesManagement.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlocksCore.ResourcesManagement
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services for managing resources.
        /// </summary>
        public static IServiceCollection AddResourceManagement(this IServiceCollection services)
        {
            services.TryAddScoped<IResourceManager, ResourceManager>();
            services.TryAddSingleton<IResourceManifestState, ResourceManifestState>();

            return services;
        }
    }
}
