using System.Collections.Generic;

namespace BlocksCore.Abstractions
{
    public interface IHostApplicationEnviroment
    {
        string EnvironmentName { get;  }
      
        string ApplicationName { get; }
        
        IEnumerable<string> ModuleNames { get; }
        
         
    }
}
