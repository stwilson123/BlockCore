using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;

namespace BlocksCore.Mvc.Core.Route
{
    public interface IRouteProvider
    {
        IList<RouteDescriptor> GetRoutes();


        Type GetRouteMapperType(RouteData routeData);
    }
}