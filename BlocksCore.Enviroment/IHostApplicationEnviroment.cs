using BlocksCore.Module.Abstractions.ModuleDescription;
using System;
using System.Collections.Generic;

namespace BlocksCore.Enviroment
{
    public interface IHostApplicationEnviroment
    {
        string EnvironmentName { get;  }
      
        string ApplicationName { get; }
        
        IEnumerable<string> ModuleNames { get; }
        
         
    }
}
