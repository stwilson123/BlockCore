using System.Collections.Generic;

namespace BlocksCore.Navigation.Abstractions
{
    public static class RouteHelper
    {
        public static string GetUrl(IDictionary<string, object> routeValue)
        {
            var controllerServiceName = routeValue["area"]?.ToString() + "/" + routeValue["controller"]?.ToString()
                                       + "/" + routeValue["action"]?.ToString();
            return controllerServiceName;
        }
    }
}
