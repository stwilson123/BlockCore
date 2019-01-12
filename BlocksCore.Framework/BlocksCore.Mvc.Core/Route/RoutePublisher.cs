using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BlocksCore.Loader.Abstractions.Shell;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace BlocksCore.Mvc.Core.Route
{
    public class RoutePublisher : IRoutePublisher
    {
        private readonly IEnumerable<IRouteProvider> _routeProviders;

        public RoutePublisher(IEnumerable<IRouteProvider> routeProviders)
        {
            _routeProviders = routeProviders;
        }

        public void Publish(IRouteBuilder routeBuilder, IEnumerable<RouteDescriptor> routes)
        {
            foreach (var route in routes)
            {
                routeBuilder.MapAreaRoute(name: route.Name, template: route.RouteTemplate,
                    areaName: route.AreaName, defaults: route.Defaults, constraints: route.Constraints
                );
            }
        }


        public void Publish(IRouteBuilder routeBuilder)
        {
            Publish(routeBuilder, _routeProviders.SelectMany(p => p.GetRoutes()));
        }
    }
}