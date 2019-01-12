using System.Collections.Generic;

namespace BlocksCore.Mvc.Core.Route
{
    public interface IRouteProvider
    {
        IList<RouteDescriptor> GetRoutes();
    }
}