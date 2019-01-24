using System;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Mvc.Core;
using BlocksCore.Mvc.Core.Route;
using BlocksCore.WebAPI.Providers;
using BlocksCore.WebAPI.Shell;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlocksCore.WebAPI
{
    public class Startup : StartupBase
    {
        private readonly IExtensionManager _extensionManager;
        public override int Order => DependencyDepth.System;


        public Startup(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            AddRouteServices(services);
            AddMvcModuleCoreServices(services);
            
           
            AddFeatureMvcControl(services);

            services.AddSingleton<ITenantShellManager, TenantShellManager>();
        }

        private void AddFeatureMvcControl(IServiceCollection services)
        {
         //  new ControllerConventional(services, _extensionManager).RegisterController();
        }

        private void AddRouteServices(IServiceCollection services)
        {
           
//            services.AddTransient<IRouteProvider, MvcRouteProvider>();
//            services.AddTransient<IRouteProvider, WebApiRouteProvider>();
            
        }

        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
        }

        internal   void AddMvcModuleCoreServices(IServiceCollection services)
        {
        }
 
    }
}