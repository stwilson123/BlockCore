using Newtonsoft.Json.Linq;

namespace OrchardCore.Infrastructure.Entities
{
    public class Entity : IEntity
    {
        public JObject Properties { get; set; } = new JObject();
    }
}
