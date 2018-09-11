using System.Collections.Generic;
using System.Linq;
using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;
using BlocksCore.SyntacticAbstractions.NullObject;

namespace BlocksCore.Enviroment.Extensions
{
    public class NullModuleInfo : IModuleInfo, INullObject
    {
        public NullModuleInfo()
        {
            
        }

        public string Name { get; }
        public string ModuleType { get; }
        public string Author { get; }
        public string Tags { get; }
        public string Version { get; }

        public IEnumerable<IFeatureInfo> Features { get; } = Enumerable.Empty<IFeatureInfo>();
    }
}