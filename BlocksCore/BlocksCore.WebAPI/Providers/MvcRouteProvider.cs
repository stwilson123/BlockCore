using System;
using System.Collections.Generic;
using System.Linq;
using Blocks.Framework.Web.Mvc.Controllers;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.DependencyInjection;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Shell.Models;
using BlocksCore.Mvc.Core.Conventions;
using BlocksCore.Mvc.Core.Route;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.WebAPI.Providers
{
    public class MvcRouteProvider : IRouteProvider
    {
        private readonly IShellHost _shellHost;
        private readonly IServiceCollection _serviceCollection;

        public MvcRouteProvider(IShellHost shellHost,IServiceCollection serviceCollection)
        {
            _shellHost = shellHost;
            _serviceCollection = serviceCollection;
        }

        public IList<RouteDescriptor> GetRoutes()
        {
            var runningShells = _shellHost.ListShellContextsAsync().Result
                .Where(sc => sc.Settings.State == TenantState.Running);

            var activeFeatures = runningShells.SelectMany(r => r.Blueprint.Descriptor.Features);
            

            return activeFeatures.Select(f =>
            {
                var areaName = AreaTemplate.GetAreaKey( new AreaOption(){ AreaName  = f.Id, FunctionType = "Views"}) ;
                return new RouteDescriptor
                {
                    Name =  areaName + "Route",
                    AreaName = areaName,
                    Priority = -10,
                    RouteTemplate =  areaName + "/{controller}/{action}/{id?}",
                    Defaults = new {area = areaName, controller = "home", action = "index"}
                };
            }).ToList();
        }

        public Type GetRouteMapperType(RouteData routeData)
        {
            string area = routeData.GetAreaName();
            string controllerName = routeData.GetControllerName();
            var serviceKey = ControllerConventional.GetControllerSerivceName(area,controllerName) + "Controller";

            return _serviceCollection.GetLastNamedServiceType(serviceKey);
        }

        
    }
}