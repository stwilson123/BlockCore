using System;
using System.Collections.Generic;
using System.Linq;
using BlocksCore.Abstractions;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Shell.Models;
using BlocksCore.Mvc.Core.Route;
using BlocksCore.WebAPI.Controllers;
using Microsoft.AspNetCore.Routing;

namespace BlocksCore.WebAPI.Providers
{
    public class WebApiRouteProvider : IRouteProvider
    {
        private readonly IShellHost _shellHost;

        public WebApiRouteProvider(IShellHost shellHost)
        {
            _shellHost = shellHost;
        }

        public Type GetRouteMapperType(RouteData routeData)
        {
            return typeof(ApiController);
        }

        public IList<RouteDescriptor> GetRoutes()
        {
            var runningShells = _shellHost.ListShellContextsAsync().Result
                .Where(sc => sc.Settings.State == TenantState.Running);

            var activeFeatures = runningShells.SelectMany(r => r.Blueprint.Descriptor.Features);
            

            return activeFeatures.Select(f =>
            {
                var areaName = AreaTemplate.GetAreaKey( new AreaOption(){ AreaName  = f.Id, FunctionType = "Api"}) ;
                return new RouteDescriptor
                {
                    Name =  areaName + "Route",
                    AreaName = areaName,
                    Priority = -10,
                    RouteTemplate =   areaName + "/{controller}/{action}/{id?}",
                    Defaults = new {area = areaName, controller = "home", action = "index"}
                };
            }).ToList();
        }
    }
}