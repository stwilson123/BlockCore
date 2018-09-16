
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.DependencyInject
{
    public interface IContainerService : IList<ServiceDescriptor>,IServiceCollection
    {
        
    }
}