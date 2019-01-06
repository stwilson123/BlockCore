using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace BlocksCore.Loader.Abstractions.Modules
{
    public interface IModularTenantRouteBuilder
    {
        IRouteBuilder Build(IApplicationBuilder appBuilder);

        void Configure(IRouteBuilder builder);
    }
}