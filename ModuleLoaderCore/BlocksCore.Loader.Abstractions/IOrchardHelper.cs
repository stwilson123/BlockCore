using Microsoft.AspNetCore.Http;

namespace BlocksCore.Loader.Abstractions
{
    public interface IOrchardHelper
    {
        HttpContext HttpContext { get; }
    }
}
