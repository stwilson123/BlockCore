using Newtonsoft.Json.Linq;

namespace BlocksCore.Infrastructure.Entities
{
    public class Entity : IEntity
    {
        public JObject Properties { get; set; } = new JObject();
    }
}
