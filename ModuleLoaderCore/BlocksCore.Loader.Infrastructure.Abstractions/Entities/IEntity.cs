using Newtonsoft.Json.Linq;

namespace OrchardCore.Infrastructure.Entities
{
    public interface IEntity
    {
        JObject Properties { get; }
    }
}
