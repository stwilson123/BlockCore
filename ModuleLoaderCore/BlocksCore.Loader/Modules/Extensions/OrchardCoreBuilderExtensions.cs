using BlocksCore.Loader.Abstractions.Modules.Builder;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Shell.Descriptor;
using BlocksCore.Loader.Abstractions.Shell.Descriptor.Models;
using BlocksCore.Loader.Environment.Shell;
using BlocksCore.Loader.Environment.Shell.Descriptor.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BlocksCore.Loader.Modules.Extensions
{
    public static partial class BlocksCoreBuilderExtensions
    {
        /// <summary>
        /// Registers at the host level a set of features which are always enabled for any tenant.
        /// </summary>
        public static BlocksCoreBuilder AddGlobalFeatures(this BlocksCoreBuilder builder, params string[] featureIds)
        {
            foreach (var featureId in featureIds)
            {
                builder.ApplicationServices.AddTransient(sp => new ShellFeature(featureId, alwaysEnabled: true));
            }

            return builder;
        }

        /// <summary>
        /// Registers at the tenant level a set of features which are always enabled.
        /// </summary>
        public static BlocksCoreBuilder AddTenantFeatures(this BlocksCoreBuilder builder, params string[] featureIds)
        {
            builder.ConfigureServices(services =>
            {
                foreach (var featureId in featureIds)
                {
                    services.AddTransient(sp => new ShellFeature(featureId, alwaysEnabled: true));
                }
            });

            return builder;
        }

        /// <summary>
        /// Registers a default tenant with a set of features that are used to setup and configure the actual tenants.
        /// For instance you can use this to add a custom Setup module.
        /// </summary>
        public static BlocksCoreBuilder AddSetupFeatures(this BlocksCoreBuilder builder, params string[] featureIds)
        {
            foreach (var featureId in featureIds)
            {
                builder.ApplicationServices.AddTransient(sp => new ShellFeature(featureId));
            }

            return builder;
        }

        /// <summary>
        /// Registers tenants defined in configuration.
        /// </summary>
        public static BlocksCoreBuilder WithTenants(this BlocksCoreBuilder builder)
        {
            var services = builder.ApplicationServices;

            services.AddSingleton<IShellSettingsConfigurationProvider, FileShellSettingsConfigurationProvider>();
            services.AddScoped<IShellDescriptorManager, FileShellDescriptorManager>();
            services.AddSingleton<IShellSettingsManager, ShellSettingsManager>();
            services.AddTransient<IConfigureOptions<ShellOptions>, ShellOptionsSetup>();
            services.AddScoped<ShellSettingsWithTenants>();

            return builder;
        }

        /// <summary>
        /// Registers a single tenant with the specified set of features.
        /// </summary>
        public static BlocksCoreBuilder WithFeatures(this BlocksCoreBuilder builder, params string[] featureIds)
        {
            foreach (var featureId in featureIds)
            {
                builder.ApplicationServices.AddTransient(sp => new ShellFeature(featureId));
            }

            builder.ApplicationServices.AddSetFeaturesDescriptor();

            return builder;
        }

        /// <summary>
        /// Registers and configures a background hosted service to manage tenant background tasks.
        /// </summary>
        public static BlocksCoreBuilder AddBackgroundService(this BlocksCoreBuilder builder)
        {
            builder.ApplicationServices.AddSingleton<IHostedService, ModularBackgroundService>();

            return builder;
        }
    }
}
