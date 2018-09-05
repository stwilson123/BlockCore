using System;
using System.Collections.Generic;

namespace BlocksCore.Enviroment
{
    public interface IApplicationEnviroment
    {
        string EnvironmentName { get;  }
      
        string ApplicationName { get; }
        
        IEnumerable<string> ModuleNames { get; }
    }
}
