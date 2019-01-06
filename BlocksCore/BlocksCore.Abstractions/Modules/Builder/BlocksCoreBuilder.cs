using System;
using System.Collections.Generic;
using BlocksCore.Abstractions.Modules.Startup;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Abstractions.Modules.Builder
{
    public class BlocksCoreBuilder
    {
        private IServiceCollection ContainerService { get; }
        private Dictionary<int, ICollection<Action<IServiceCollection, IServiceProvider>>> _actions { get; } = new Dictionary<int, ICollection<Action<IServiceCollection, IServiceProvider>>>();

        public BlocksCoreBuilder(IServiceCollection services)
        {
            ContainerService = services;
        }


        public BlocksCoreBuilder ConfigureServices(Action<IServiceCollection,IServiceProvider> action,int order = 0)
        {
            if (!_actions.TryGetValue(order, out var currentActions))
            {
                currentActions = _actions[order] = new List<Action<IServiceCollection, IServiceProvider>>();
                ContainerService.AddTransient<IModuleStartup>((s) =>
                    new SystemModuleStartup(order: order, serviceProvider: s.GetRequiredService<IServiceProvider>(),
                        configureServicesActions: currentActions));
            }
            currentActions.Add(action);   
            return this;
        }
        
        
        
        
        
    }
}
