using System;
using BlocksCore.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlocksCore.Test.DependencyInjection.Model
{
    public class TestScope
    {
        [Fact]
        public void Scope_instance_should_differentparent()
        {
            
            
            
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IName, Name>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var service =  serviceProvider.GetService<IName>();

            var serviceB = serviceProvider.CreateScope().ServiceProvider.GetService<IName>();
            
            Assert.Same(service, serviceB);
        }
    }
}