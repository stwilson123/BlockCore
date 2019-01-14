using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using BlocksCore.Exception;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Abstractions.DependencyInjection
{
    public static class DependencyInjectionServiceExtensions
    {
        static NamedServiceDicionary Types = new NamedServiceDicionary();
        public static IServiceCollection AddSingleton(this IServiceCollection serviceCollection,string serviceKey,Type serviceType, Type implementationType)
        {
            return Add(serviceCollection, serviceKey, serviceType, implementationType, ServiceLifetime.Singleton);

        }

        
        
        public static IServiceCollection AddTransient(this IServiceCollection serviceCollection,string serviceKey,Type serviceType, Type implementationType)
        {
            return Add(serviceCollection, serviceKey, serviceType, implementationType, ServiceLifetime.Transient);
        }
        
        public static IServiceCollection AddTransient<TService,TImplement>(this IServiceCollection serviceCollection,string serviceKey)
        {
            return Add(serviceCollection, serviceKey, typeof(TService), typeof(TImplement), ServiceLifetime.Transient);
            
        }
        public static IServiceCollection AddScoped(this IServiceCollection serviceCollection,string serviceKey,Type serviceType, Type implementationType)
        {
            return Add(serviceCollection, serviceKey, serviceType, implementationType, ServiceLifetime.Scoped);

        }
        
        private static IServiceCollection Add(IServiceCollection serviceCollection,string serviceKey,Type serviceType, Type implementationType,  ServiceLifetime lifetime)
        {
            
            serviceCollection.Add(new ServiceDescriptor(implementationType,implementationType,lifetime));

            var dicKey = new KeyValuePair<string, Type>(serviceKey,serviceType);
            Types.Add(dicKey, implementationType);
            return serviceCollection;
            
        }
        
        public static T GetService<T>(this IServiceProvider serviceProvider,string serviceKey)
        {

            return (T)GetService(serviceProvider, serviceKey, typeof(T));
        }
        public static object GetService(this IServiceProvider serviceProvider,string serviceKey,Type serviceType)
        {
            
            var dicKey = new KeyValuePair<string, Type>(serviceKey,serviceType);
            
            var lastestType =  Types.Get(dicKey).LastOrDefault();
            if (lastestType == null)
            {
                throw new BlocksException($"Type {serviceType} is not register.");
            }

            return serviceProvider.GetService(lastestType);
        }
        
        
        
     
        
    }
}