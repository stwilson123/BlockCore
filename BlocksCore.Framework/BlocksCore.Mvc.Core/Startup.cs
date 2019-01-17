using System;
using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Mvc.Core.Controller;
using BlocksCore.Mvc.Core.LocationExpander;
using BlocksCore.Mvc.Core.RazorPages;
using BlocksCore.Mvc.Core.Route;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace BlocksCore.Mvc.Core
{
    public class Startup : StartupBase
    {
        public override int Order => -200;

        private readonly IServiceProvider _serviceProvider;

        public Startup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            
            var builder = services.AddMvc(options =>
            {
                 
            });
        
            services.AddMvcCore().AddModularRazorPages();

            
            
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<RazorViewEngineOptions>, ModularRazorViewEngineOptionsSetup>());
            
            // Use a custom IViewCompilerProvider so that all tenants reuse the same ICompilerCache instance
            builder.Services.Replace(new ServiceDescriptor(typeof(IViewCompilerProvider), typeof(SharedViewCompilerProvider), ServiceLifetime.Singleton));
            
            
             AddRouteServices(services);
             AddMvcModuleCoreServices(services);
        }

        private void AddRouteServices(IServiceCollection services)
        {
            services.AddTransient<IRoutePublisher, RoutePublisher>();
            
        }

        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            
        }

        internal static void AddMvcModuleCoreServices(IServiceCollection services)
        {
            services.Replace(
                ServiceDescriptor.Transient<IModularTenantRouteBuilder, ModularTenantRouteBuilder>());
            
            
            services.AddScoped<IViewLocationExpanderProvider, ComponentViewLocationExpanderProvider>();

            services.TryAddEnumerable(
                ServiceDescriptor.Singleton<IApplicationModelProvider, ModularApplicationModelProvider>());
       
        
        
            services.Replace(ServiceDescriptor.Singleton<IControllerFactory, BlocksWebMvcControllerFactory>());
       
            
        }

    }
}