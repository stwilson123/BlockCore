using BlocksCore.Loader.Abstractions;
using Microsoft.AspNetCore.Http;

namespace BlocksCore.Loader.Modules
{
    public class DefaultOrchardHelper : IOrchardHelper
    {
        public DefaultOrchardHelper(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
        }

        public HttpContext HttpContext { get; set; }
    }
}
