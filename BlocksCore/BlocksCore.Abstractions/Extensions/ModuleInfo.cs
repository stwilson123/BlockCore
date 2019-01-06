using System.Collections.Generic;
using System.Linq;
using BlocksCore.Abstractions.Extensions.Features;
using BlocksCore.Abstractions.Modules.ModuleDescription;

namespace BlocksCore.Abstractions.Extensions
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