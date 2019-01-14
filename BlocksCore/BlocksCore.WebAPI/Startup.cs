using System;
using BlocksCore.Abstractions;
using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Mvc.Core;
using BlocksCore.Mvc.Core.Route;
using BlocksCore.WebAPI.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlocksCore.WebAPI
{
    public class Startup : StartupBase
    {
        public override int Order => DependencyDepth.System;

        private readonly IServiceProvider _serviceProvider;

        public Startup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            
 

            AddRouteServices(services);
            AddMvcModuleCoreServices(services);
        }

        private void AddRouteServices(IServiceCollection services)
        {
           
            services.AddTransient<IRouteProvider, MvcRouteProvider>();
            services.AddTransient<IRouteProvider, WebApiRouteProvider>();
            
        }

        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            
        }

        internal static void AddMvcModuleCoreServices(IServiceCollection services)
        {
           
        }

    
    }
}