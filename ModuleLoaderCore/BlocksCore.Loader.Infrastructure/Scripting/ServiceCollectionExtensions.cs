using BlocksCore.Loader.Infrastructure.Scripting.Files;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Infrastructure.Scripting;

namespace BlocksCore.Loader.Infrastructure.Scripting
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScripting(this IServiceCollection services)
        {
            services.AddSingleton<IScriptingManager, DefaultScriptingManager>();
            services.AddSingleton<IGlobalMethodProvider, CommonGeneratorMethods>();

            services.AddSingleton<IScriptingEngine, FilesScriptEngine>();
            return services;
        }
    }
}