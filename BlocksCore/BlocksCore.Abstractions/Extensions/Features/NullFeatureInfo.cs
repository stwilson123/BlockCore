using BlocksCore.SyntacticAbstractions.NullObject;

namespace BlocksCore.Abstractions.Extensions.Features
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