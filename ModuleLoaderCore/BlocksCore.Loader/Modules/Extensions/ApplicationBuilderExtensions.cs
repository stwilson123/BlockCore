using System;
using BlocksCore.Loader.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace BlocksCore.Loader.Modules.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Enables multi-tenant requests support for the current path.
        /// </summary>
        public static IApplicationBuilder UseBlocksCore(this IApplicationBuilder app, Action<IApplicationBuilder> configure = null)
        {
            var env = app.ApplicationServices.GetRequiredService<IHostingEnvironment>();
            var appContext = app.ApplicationServices.GetRequiredService<IApplicationContext>();

            env.ContentRootFileProvider = new CompositeFileProvider(
                new ModuleEmbeddedFileProvider(appContext),
                env.ContentRootFileProvider);

            app.UseMiddleware<PoweredByMiddleware>();

            // Ensure the shell tenants are loaded when a request comes in
            // and replaces the current service provider for the tenant's one.
            app.UseMiddleware<ModularTenantContainerMiddleware>();

            configure?.Invoke(app);

            app.UseMiddleware<ModularTenantRouterMiddleware>(app.ServerFeatures);

            return app;
        }
    }
}