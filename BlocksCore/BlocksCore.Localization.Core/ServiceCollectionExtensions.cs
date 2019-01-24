using BlocksCore.Localization.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Localization.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLocalizationCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILocalizationManager, LocalizationManager>();
            serviceCollection.AddSingleton<IStringLocalizerFactory, DefaultModularLocalizerFactory>();

            
            return serviceCollection;
        }
    }
}