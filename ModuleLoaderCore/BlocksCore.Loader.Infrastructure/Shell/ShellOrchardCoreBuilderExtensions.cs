using BlocksCore.Loader.Abstractions.Modules.Builder;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Loader.Environment.Shell;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
//using BlocksCore.Environment.Shell.Data.Descriptors;

namespace BlocksCore.Loader.Infrastructure.Shell
{
    public static class ShellBlocksCoreBuilderExtensions
    {
        /// <summary>
        /// Adds services at the host level to load site settings from the file system
        /// and tenant level services to store states and descriptors in the database.
        /// </summary>
        public static BlocksCoreBuilder AddDataStorage(this BlocksCoreBuilder builder)
        {
            builder.AddSitesFolder()
                .ConfigureServices(services =>
                {
                    //services.AddScoped<IShellDescriptorManager, ShellDescriptorManager>();
                    //services.AddScoped<IShellStateManager, ShellStateManager>();
                    services.AddScoped<IShellFeaturesManager, ShellFeaturesManager>();
                    services.AddScoped<IShellDescriptorFeaturesManager, ShellDescriptorFeaturesManager>();
                });

            return builder;
        }

        /// <summary>
        /// Host services to load site settings from the file system
        /// </summary>
        public static BlocksCoreBuilder AddSitesFolder(this BlocksCoreBuilder builder)
        {
            var services = builder.ApplicationServices;

            services.AddSingleton<IShellSettingsConfigurationProvider, ShellSettingsConfigurationProvider>();
            services.AddSingleton<IShellSettingsManager, ShellSettingsManager>();
            services.AddTransient<IConfigureOptions<ShellOptions>, ShellOptionsSetup>();

            return builder;
        }
    }
}