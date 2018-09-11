using System.Collections.Generic;
using System.Linq;
using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;
using BlocksCore.Module.Abstractions.ModuleDescription;

namespace BlocksCore.Enviroment.Extensions
{
    public class ModuleInfo : IModuleInfo
    {
        private readonly ModuleAttribute _moduleAttribute;

        public ModuleInfo(ModuleAttribute moduleAttribute)
        {
            _moduleAttribute = moduleAttribute;
            Name = _moduleAttribute.Name;
            ModuleType = _moduleAttribute.ModuleType;
            Author = _moduleAttribute.Author;
            Tags = _moduleAttribute.Tags;
            Version = _moduleAttribute.Version;
        }

        public string Name { get; }
        public string ModuleType { get; private set; }
        public string Author { get; private set; }
        public string Tags { get; private set; }
        public string Version { get;private set; }

        public IEnumerable<IFeatureInfo> Features { get; internal set; } = Enumerable.Empty<IFeatureInfo>();
    }
}