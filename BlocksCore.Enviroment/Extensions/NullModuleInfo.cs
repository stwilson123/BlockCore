using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.SyntacticAbstractions.NullObject;

namespace BlocksCore.Enviroment.Extensions
{
    public class NullModuleInfo : IModuleInfo, INullObject
    {
        public NullModuleInfo()
        {
            
        }
        public string ModuleType { get; }
        public string Author { get; }
        public string Tags { get; }
        public string Version { get; }
    }
}