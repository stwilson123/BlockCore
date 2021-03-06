using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Loader.Modules.Extensions
{
    public static class PoweredByBlocksCoreExtensions
    {
        /// <summary>
        /// Configures whether use or not the Header X-Powered-By.
        /// Default value is BlocksCore.
        /// </summary>
        /// <param name="app">The modular application builder</param>
        /// <param name="enabled">Boolean indicating if the header should be included in the response or not</param>
        /// <returns>The modular application builder</returns>
        public static IApplicationBuilder UsePoweredByBlocksCore(this IApplicationBuilder app, bool enabled)
        {
            var options = app.ApplicationServices.GetRequiredService<IPoweredByMiddlewareOptions>();
            options.Enabled = enabled;

            return app;
        }

        /// <summary>
        /// Configures wethere use or not the Header X-Powered-By and its value.
        /// Default value is BlocksCore.
        /// </summary>
        /// <param name="app">The modular application builder</param>
        /// <param name="enabled">Boolean indicating if the header should be included in the response or not</param>
        /// <param name="headerValue">Header's value</param>
        /// <returns>The modular application builder</returns>
        public static IApplicationBuilder UsePoweredBy(this IApplicationBuilder app, bool enabled, string headerValue)
        {
            var options = app.ApplicationServices.GetRequiredService<IPoweredByMiddlewareOptions>();
            options.Enabled = enabled;
            options.HeaderValue = headerValue;

            return app;
        }
    }
}