using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Blocks.Framework.Web.Mvc.Controllers;
using Blocks.Framework.Web.Mvc.Controllers.Builder;
using Blocks.Framework.Web.Mvc.Controllers.Factory;
using Blocks.Framework.Web.Mvc.Controllers.Manager;
using BlocksCore.Abstractions.DependencyInjection;
using BlocksCore.Application.Abstratctions.Controller.Factory;
using BlocksCore.Application.Core.Manager;
using BlocksCore.SyntacticAbstractions.Types;
using BlocksCore.Test.Application.Controller.TestModel;
using BlocksCore.Test.WebApi.Controller.TestModel;
using BlocksCore.Web.Abstractions.HttpMethod;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
 

namespace Blocks.Framework.Web.Test.Mvc.Controller.Factory
{
    public class MvcControllerBuilderFactoryTest  
    {
        private readonly IEnumerable<Type> servicesType;

        private IServiceProvider serviceProvider;
        
        private string ModuleName = "TestModule";

        public MvcControllerBuilderFactoryTest()
        {
            
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<MvcControllerManager>();
            serviceCollection.AddTransient<TestMvcController>();
            
            
            serviceProvider = serviceCollection.BuildServiceProvider();
           
            servicesType = serviceCollection.Select(service => service.ImplementationType).ToList();


        }
        
        [Fact]
        public void GetAppServiceForOneWithDefault()
        {
            var serviceName = ModuleName + "/Test";
            IDefaultControllerBuilderFactory factory = new MvcControllerBuilderFactory(serviceProvider,new MvcControllerOption()
            {
                 ApiControllerType = typeof(Microsoft.AspNetCore.Mvc.Controller)
                 
                
            });
            factory.For<TestMvcController>(serviceName).WithApiExplorer(true).Build();

            TestControllerForTestController(serviceName);
        }

        [Fact]
        public void GetAllControllerForAll()
        {
            var servicePrefix =ModuleName.ToCamelCase();
            var serviceName = servicePrefix + "/"+"TestMvc".ToCamelCase().RemovePostFix(ControllerConventional.Postfixes()); ;
            IDefaultControllerBuilderFactory factory = new MvcControllerBuilderFactory(serviceProvider,new MvcControllerOption()
            {
                ApiControllerType = typeof(Microsoft.AspNetCore.Mvc.Controller)
                 
                
            });
            factory.ForAll<Microsoft.AspNetCore.Mvc.Controller>(servicePrefix,servicesType).Build();

            TestControllerForTestController(serviceName);
        }

        private void TestControllerForTestController(string serviceName)
        {
            var defaultControllermanager = serviceProvider.GetService<MvcControllerManager>();
            var testController = defaultControllermanager.FindOrNull(serviceName);
            Assert.NotNull(testController);
            Assert.Equal(testController.ServiceName, serviceName);
          //  Assert.True(testController.IsApiExplorerEnabled);
            Assert.True(testController.ApiControllerType == typeof(Microsoft.AspNetCore.Mvc.Controller));

            var controllerActionDefault = testController.Actions.FirstOrDefault(t => t.Key == "Default");
            Assert.NotNull(controllerActionDefault.Value);
            Assert.Equal("Default", controllerActionDefault.Value.ActionName);
            Assert.Equal(HttpVerb.Get, controllerActionDefault.Value.Verb);


            var controllerActionDelete = testController.Actions.FirstOrDefault(t => t.Key == "TestDelete");
            Assert.NotNull(controllerActionDelete.Value);
            Assert.Equal("TestDelete", controllerActionDelete.Value.ActionName);
            Assert.Equal(HttpVerb.Delete, controllerActionDelete.Value.Verb);

            var controllerActionIgnore = testController.Actions.FirstOrDefault(t => t.Key == "TestIgnore");
            Assert.Null(controllerActionIgnore.Value);

            var controllerActionNoActionName = testController.Actions.FirstOrDefault(t => t.Key == "TestNoActionName");
            Assert.Null(controllerActionNoActionName.Value);
        }
    }
}