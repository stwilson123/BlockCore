﻿using System;
using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Mvc.Core.Route;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            
//            var builder = services.AddMvcCore(options =>
//            {
//                options.Conventions.Add(new ConsumesConstraintForFormFileParameterConvention());
//            });
//            

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
        }

    }
}