using System;
using System.Collections.Generic;
using BlocksCore.Application.Abstratctions.Controller.Builder;
using BlocksCore.Application.Abstratctions.Controller.Factory;
using BlocksCore.Application.Core.Controller.Builder;
using BlocksCore.Application.Core.Manager;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Application.Core.Controller.Factory
{
    public class DefaultControllerBuilderFactory : IDefaultControllerBuilderFactory
    {
        protected readonly IServiceProvider _serviceProvider;

        public DefaultControllerBuilderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Generates a new dynamic api controller for given type.
        /// </summary>
        /// <param name="serviceName">Name of the Api controller service. For example: 'myapplication/myservice'.</param>
        /// <typeparam name="T">Type of the proxied object</typeparam>
        public virtual IDefaultControllerBuilder<T> For<T>(string serviceName)
        {
            return new DefaultControllerBuilder<T,DefaultControllerActionBuilder<T>>(serviceName, _serviceProvider,_serviceProvider.GetService<DefaultControllerManager>());
        }

        /// <summary>
        /// Generates multiple dynamic api controllers.
        /// </summary>
        /// <typeparam name="T">Base type (class or interface) for services</typeparam>
        /// <param name="assembly">Assembly contains types</param>
        /// <param name="servicePrefix">Service prefix</param>
        public virtual IBatchDefaultControllerBuilder<T> ForAll<T>(string servicePrefix,IEnumerable<Type> serviceTypes)
        {
            return new BatchDefaultControllerBuilder<T>(this, servicePrefix,serviceTypes);
        }
    }
}