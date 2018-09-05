namespace BlocksCore.Enviroment.Extensions.Abstractions
{
    public interface IModuleInfo
    {
        string ModuleType { get;  }
        
        string Author { get;  }
        
        string Tags { get;   }

        string Version { get;   }
    }
}