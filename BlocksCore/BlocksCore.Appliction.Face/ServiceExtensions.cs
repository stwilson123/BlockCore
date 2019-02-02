using System;
using BlocksCore.Data;
using BlocksCore.Loader.Abstractions.Modules.Builder;
using BlocksCore.Loader.DeferredTasks;
using BlocksCore.Loader.Infrastructure.Cache;
using BlocksCore.Loader.Infrastructure.Shell;
using BlocksCore.Loader.Modules.Extensions;
using BlocksCore.Mvc.Core.Extensions;
using BlocksCore.ResourcesManagement;
using BlocksCore.ResourcesManagement.TagHelpers;
using BlocksCore.WebAPI.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds Orchard CMS services to the application. 
        /// </summary>
        public static IServiceCollection AddBlocksCoreKernel(this IServiceCollection services)
        {
            return AddBlocksCoreKernel(services, null);
        }

        /// <summary>
        /// Adds Orchard CMS services to the application and let the app change the
        /// default tenant behavior and set of features through a configure action.
        /// </summary>
        public static IServiceCollection AddBlocksCoreKernel(this IServiceCollection services, Action<BlocksCoreBuilder> configure)
        {

            var builder = services.AddBlocksCore()

               // .AddCommands()
                .AddWebApi()
                .AddMvc()

                //.AddSetupFeatures("OrchardCore.Setup")

                .AddDataAccess()
               .AddDataStorage()
                .AddBackgroundService()
                .AddDeferredTasks()

               // .AddTheming()
                //.AddLiquidViews()
                .AddCaching();

            // OrchardCoreBuilder is not available in OrchardCore.ResourceManagement as it has to
            // remain independent from OrchardCore.
            builder.ConfigureServices(s =>
            {
                s.AddResourceManagement();

                //s.AddTagHelpers<LinkTagHelper>();
                //s.AddTagHelpers<MetaTagHelper>();
                //s.AddTagHelpers<ResourcesTagHelper>();
                //s.AddTagHelpers<ScriptTagHelper>();
                //s.AddTagHelpers<StyleTagHelper>();
            });

           // builder.Configure(app => app.UseDataAccess());

            configure?.Invoke(builder);

            return services;
        }
    }
}
