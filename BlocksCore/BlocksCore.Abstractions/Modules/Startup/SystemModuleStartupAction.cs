using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Abstractions.Modules.Startup
{
    internal class SystemModuleStartupAction 
    {
        public int Order { get; }
        
        public ICollection<Action<IServiceCollection, IServiceProvider>> ConfigureServicesActions { get; } = new List<Action<IServiceCollection, IServiceProvider>>();

    }
}