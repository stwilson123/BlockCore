using BlocksCore.Module.Abstractions.ModuleDescription;
using System;
using System.Collections.Generic;

namespace BlocksCore.Enviroment
{
    public interface IApplicationEnviroment
    {
        string EnvironmentName { get;  }
      
        string ApplicationName { get; }
        
        IEnumerable<ModuleAttribute> ModuleDescriptions { get; }
    }
}
