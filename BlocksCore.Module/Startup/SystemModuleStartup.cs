using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Module.Startup
{
    internal class SystemModuleStartup : ModuleStartup
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ICollection<Action<IServiceCollection, IServiceProvider>> _configureServicesActions;

        public SystemModuleStartup(IServiceProvider serviceProvider, ICollection<Action<IServiceCollection, IServiceProvider>> configureServicesActions,int order = 0)
        {
            _serviceProvider = serviceProvider;
            _configureServicesActions = configureServicesActions;
            Order = order;
        }
        public override int Order { get;  }
        


        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            foreach (var configureServicesAction in _configureServicesActions)
            {
                configureServicesAction?.Invoke(serviceCollection,_serviceProvider);
             //   configureServicesAction?.Invoke(_serviceProvider,serviceCollection);
            }

          
        }
    }
}