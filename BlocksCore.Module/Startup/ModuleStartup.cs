using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Module.Startup
{
    public abstract class ModuleStartup : IModuleStartup
    {
        public virtual int Order { get; } = 10;
        public virtual void ConfigureServices(IServiceCollection serviceCollection)
        {
            throw new System.NotImplementedException();
        }
    }
}