using BlocksCore.Enviroment.Extensions.Abstractions.Features;
using System.Collections.Generic;

namespace BlocksCore.Enviroment.Extensions.Abstractions
{
    public interface IModuleInfo
    {
        string Name { get; }
        
        string ModuleType { get;  }
        
        string Author { get;  }
        
        string Tags { get;   }

        string Version { get;   }

        IEnumerable<IFeatureInfo> Features { get;  }

    }
}