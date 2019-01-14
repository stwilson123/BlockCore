//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Reflection;
//using Blocks.Framework.ApplicationServices.Controller.Factory;
//using Blocks.Framework.ApplicationServices.Manager;
//using Blocks.Framework.Web.Test.Application.Controller.TestModel;
//using Blocks.Framework.Web.Test.Mvc.Controller.TestModel;
//using BlocksCore.SyntacticAbstractions.Types;
//using BlocksCore.Web.Abstractions.Attributes;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;
// 
//
//namespace Blocks.Framework.Web.Test.Mvc.Controller.Factory
//{
//    public class MvcControllerBuilderFactoryTest  
//    {
//        private IEnumerable<Type> servicesType;
//
//        private IServiceProvider serviceProvider;
//        
//        private string ModuleName = "TestModule";
//
//        public MvcControllerBuilderFactoryTest()
//        {
//            
//            IServiceCollection serviceCollection = new ServiceCollection();
//            serviceCollection.AddSingleton<DefaultControllerManager>();
//            serviceCollection.AddTransient<ITestAppService, TestAppService>();
//            
//            
//            serviceProvider = serviceCollection.BuildServiceProvider();
//           
//            servicesType = serviceCollection.Select(service => service.ImplementationType).ToList();
//
//
//        }
//        
//        [Fact]
//        public void GetAppServiceForOneWithDefault()
//        {
//            var serviceName = ModuleName + "/Test";
//            IDefaultControllerBuilderFactory factory = new MvcControllerBuilderFactory(serviceProvider);
//            factory.For<TestMvcController>(serviceName).WithApiExplorer(true).Build();
//
//            TestControllerForTestController(serviceName);
//        }
//
//        [Fact]
//        public void GetAllControllerForAll()
//        {
//            var servicePrefix = TestModule.ModuleName.ToCamelCase();
//            var serviceName = servicePrefix + "/"+"TestMvc".ToCamelCase().RemovePostFix(BlocksWebMvcController.Postfixes); ;
//            IDefaultControllerBuilderFactory factory = new MvcControllerBuilderFactory(LocalIocManager);
//            factory.ForAll<BlocksWebMvcController>(servicePrefix,servicesType).Build();
//
//            TestControllerForTestController(serviceName);
//        }
//
//        private void TestControllerForTestController(string serviceName)
//        {
//            var defaultControllermanager = LocalIocManager.Resolve<MvcControllerManager>();
//            var testController = defaultControllermanager.FindOrNull(serviceName);
//            Assert.NotNull(testController);
//            Assert.Equal(testController.ServiceName, serviceName);
//          //  Assert.True(testController.IsApiExplorerEnabled);
//            Assert.True(testController.ApiControllerType == typeof(BlocksWebMvcController));
//
//            var controllerActionDefault = testController.Actions.FirstOrDefault(t => t.Key == "Default");
//            Assert.NotNull(controllerActionDefault.Value);
//            Assert.Equal("Default", controllerActionDefault.Value.ActionName);
//            Assert.Equal(HttpVerb.Get, controllerActionDefault.Value.Verb);
//
//
//            var controllerActionDelete = testController.Actions.FirstOrDefault(t => t.Key == "TestDelete");
//            Assert.NotNull(controllerActionDelete.Value);
//            Assert.Equal("TestDelete", controllerActionDelete.Value.ActionName);
//            Assert.Equal(HttpVerb.Delete, controllerActionDelete.Value.Verb);
//
//            var controllerActionIgnore = testController.Actions.FirstOrDefault(t => t.Key == "TestIgnore");
//            Assert.Null(controllerActionIgnore.Value);
//
//            var controllerActionNoActionName = testController.Actions.FirstOrDefault(t => t.Key == "TestNoActionName");
//            Assert.Null(controllerActionNoActionName.Value);
//        }
//    }
//}