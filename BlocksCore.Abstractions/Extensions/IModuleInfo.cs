using System.Collections.Generic;
using BlocksCore.Abstractions.Extensions.Features;

namespace BlocksCore.Abstractions.Extensions
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