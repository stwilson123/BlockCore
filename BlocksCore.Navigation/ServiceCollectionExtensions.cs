using System.Resources;
using Blocks.Framework.Navigation.Manager;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlocksCore.Navigation
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services for managing resources.
        /// </summary>
        public static IServiceCollection AddResourceManagement(this IServiceCollection services)
        {
            services.TryAddSingleton<INavigationManager, NavigationManager>();

            return services;
        }
    }
}