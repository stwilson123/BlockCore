using Microsoft.AspNetCore.Mvc.Razor;

namespace BlocksCore.Mvc.Core.LocationExpander
{
    public interface IViewLocationExpanderProvider : IViewLocationExpander
    {
        int Priority { get; }
    }
}
