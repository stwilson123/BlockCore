using Newtonsoft.Json.Linq;

namespace BlocksCore.Infrastructure.Entities
{
    public interface IEntity
    {
        JObject Properties { get; }
    }
}
