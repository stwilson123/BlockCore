using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace BlocksCore.Mvc.Core.Route
{
    public interface IRoutePublisher
    {
        void Publish(IRouteBuilder routeBuilder,IEnumerable<RouteDescriptor> routes);


        void Publish(IRouteBuilder routeBuilder);

    }
}