using System;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Module.Startup
{
    public interface IModuleStartup
    {
        int Order { get; }

        void ConfigureServices(IServiceCollection serviceCollection);
    }
}