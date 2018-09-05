using System.Reflection;
using BlocksCore.Enviroment.Extensions.Abstractions;

namespace BlocksCore.Enviroment.Extensions
{
    public class ModuleEntry
    {
        public ModuleEntry(IModuleInfo moduleInfo, Assembly assembly)
        {
            ModuleInfo = moduleInfo;
            Assembly = assembly;
        }
        public IModuleInfo ModuleInfo { get;  }
        
        public Assembly Assembly { get;  }
        
        
    }
}