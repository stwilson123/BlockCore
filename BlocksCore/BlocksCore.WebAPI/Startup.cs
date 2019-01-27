using System;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.Shell;
using BlocksCore.Application.Abstratctions;
using BlocksCore.Application.Core.Controller.Factory;
using BlocksCore.Application.Core.Manager;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Mvc.Core;
using BlocksCore.Mvc.Core.Conventions;
using BlocksCore.Mvc.Core.Route;
using BlocksCore.WebAPI.Controllers;
using BlocksCore.WebAPI.Controllers.Builder;
using BlocksCore.WebAPI.Controllers.Factory;
using BlocksCore.WebAPI.Controllers.Manager;
using BlocksCore.WebAPI.Providers;
using BlocksCore.WebAPI.Shell;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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

        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {

        }



        private void AddFeatureMvcControl(IServiceCollection services)
        {
            var defaultMvcControllerManager = new MvcControllerManager();


            new ApiControllerConventional(_extensionManager, new MvcControllerBuilderFactory(new MvcControllerOption(typeof(IAppService)),
                defaultMvcControllerManager)).RegisterController();

            services.AddMvcCore(opt =>
                {
                    opt.Conventions.Add(new ControllerModelConvention(defaultMvcControllerManager));
                    opt.Conventions.Add(new BlocksCore.WebAPI.ActionModelConvention());
                    //opt.Conventions.Add(new ParameterModelConvention(typeof(ITestService)));
                })
                .ConfigureApplicationPartManager(manager =>
                {
                    var featureProvider = new ServiceControllerFeatureProvider(defaultMvcControllerManager);
                    manager.FeatureProviders.Add(featureProvider);
                }).AddXmlSerializerFormatters()
                .AddXmlDataContractSerializerFormatters();

            services.AddSingleton(defaultMvcControllerManager);

        }

        private void AddRouteServices(IServiceCollection services)
        {
             services.AddTransient<IRouteProvider, WebApiRouteProvider>();

        }


        private void AddMvcModuleCoreServices(IServiceCollection services)
        {
            services.TryAddEnumerable(
             ServiceDescriptor.Singleton<IApplicationModelProvider, ModularApplicationApiModelProvider>());
        }

    }
}