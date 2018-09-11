using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;
using BlocksCore.SyntacticAbstractions.NullObject;

namespace BlocksCore.Enviroment.Extensions.Features
{
    public class NullFeatureInfo : IFeatureInfo, INullObject
    {
        public string Id { get; }
        public string Name { get; }
        public string Priority { get; }
        public string Description { get; }
        public IModuleInfo ModuleInfo { get; }
        public string[] Dependencies { get; }
    }
}