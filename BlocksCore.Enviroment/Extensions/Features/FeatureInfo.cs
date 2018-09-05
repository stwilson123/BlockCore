using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;

namespace BlocksCore.Enviroment.Extensions.Features
{
    public class FeatureInfo : IFeatureInfo
    {
        public FeatureInfo()
        {
            
        }
        public string Id { get;  }
        public string Name { get; }
        public int Priority { get; }
        public string Description { get; }
        public IModuleInfo ModuleInfo { get; }
        public string[] Dependencies { get; }
    }
}