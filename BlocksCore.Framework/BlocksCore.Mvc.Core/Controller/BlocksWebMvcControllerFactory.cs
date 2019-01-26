using System;
using System.Collections.Generic;
using System.Linq;
using BlocksCore.Mvc.Core.Conventions;
using BlocksCore.Mvc.Core.Route;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using BlocksCore.Abstractions.DependencyInjection;
using BlocksCore.Loader.Abstractions.Shell.Builders;

namespace BlocksCore.Mvc.Core.Controller
{
    public class BlocksWebMvcControllerFactory :  DefaultControllerFactory
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IEnumerable<IRouteProvider> _routeProviders;

        public BlocksWebMvcControllerFactory(IControllerActivator controllerActivator,
            IEnumerable<IControllerPropertyActivator> propertyActivators,
            IServiceCollection serviceCollection,
            IEnumerable<IRouteProvider> routeProviders) : base(controllerActivator, propertyActivators)
        {
            _serviceCollection = serviceCollection;
            _routeProviders = routeProviders;
        }


        public override object CreateController(ControllerContext context)
        {
            return base.CreateController(context);
            //var controllerType = default(Type);
            
            //var shellContext = context.HttpContext.Features.Get<ShellContext>();

            //foreach (var routeProvider in _routeProviders)
            //{
            //    controllerType = routeProvider.GetRouteMapperType(context.RouteData);
            //    if (controllerType != null)
            //        break;
            //}
            
            //if (controllerType == null || !_serviceCollection.Contians(controllerType))
            //   return base.CreateController(context);
             
            //return shellContext.ServiceProvider.GetService(controllerType);
        }


         
    }
}