using System.Linq;
using BlocksCore.Loader.Infrastructure.Security.AuthorizationHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Loader.Infrastructure.Security
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds tenant level services.
        /// </summary>
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddAuthentication((options) =>
            {
                if (!options.Schemes.Any(x => x.Name == "Api"))
                {
                    options.AddScheme<ApiAuthenticationHandler>("Api", null);
                }
            });

            services.AddScoped<IAuthorizationHandler, SuperUserHandler>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            return services;
        }
    }
}