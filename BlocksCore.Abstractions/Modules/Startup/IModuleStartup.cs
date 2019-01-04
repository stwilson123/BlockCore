using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Abstractions.Modules.Startup
{
    public interface IModuleStartup
    {
        int Order { get; }

        void ConfigureServices(IServiceCollection serviceCollection);
    }
}