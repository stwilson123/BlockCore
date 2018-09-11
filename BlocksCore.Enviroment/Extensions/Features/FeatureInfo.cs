using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;
using BlocksCore.Module.Abstractions.ModuleDescription;

namespace BlocksCore.Enviroment.Extensions.Features
{
    public class FeatureInfo : IFeatureInfo
    {
        internal FeatureInfo()
        {

        }
        public FeatureInfo(FeatureAttribute feature)
        {
            this.Id = feature.Id;
            this.Name = feature.Name;
            this.Priority = feature.Priority;
            this.Description = feature.Description;
            this.Dependencies = feature.Dependencies;
        }
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Priority { get; internal set; }
        public string Description { get; internal set; }
        public IModuleInfo ModuleInfo { get; internal set; }
        public string[] Dependencies { get; internal set; }
    }
}