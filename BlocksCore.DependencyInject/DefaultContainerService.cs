using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.DependencyInject
{
    public class DefaultContainerService : IContainerService
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IServiceProvider _serviceProvider;


        public DefaultContainerService(IServiceCollection serviceCollection,IServiceProvider serviceProvider)
        {
            _serviceCollection = serviceCollection;
            _serviceProvider = serviceProvider;
        }


        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
        public int IndexOf(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public ServiceDescriptor this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}