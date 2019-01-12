using Microsoft.AspNetCore.Routing;

namespace BlocksCore.Mvc.Core.Route
{
    public class RouteDescriptor
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        
        public string AreaName { get; set; }
        public string RouteTemplate { get; set; }
        public object Defaults { get; set; }
        public object Constraints { get; set; }
    }
}