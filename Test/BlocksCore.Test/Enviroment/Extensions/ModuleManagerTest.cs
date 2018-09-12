using System;
using System.Collections.Generic;
using System.Linq;
using BlocksCore.Enviroment;
using BlocksCore.Enviroment.Extensions;
using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Module.Abstractions.ModuleDescription;
using BlocksCore.Test.Stubs;
using Xunit;
using BlocksCore.SyntacticAbstractions.NullObject;
namespace BlocksCore.Test.Enviroment.Extensions
{
    public class ModuleManagerTest
    {

        private IHostApplicationEnviroment _hostApplicationEnviroment = new StubHostApplicationEnviroment();
        private IModuleManager _moduleManager;
        public ModuleManagerTest()
        {
           _moduleManager = new ModuleManager(_hostApplicationEnviroment,new FeatureInspect());
        }
        
        [Fact]
        public void StubObjectShouldReturnModuleAndFeatures()
        {
            Assert.Contains(_moduleManager.GetModuleInfos(),t => string.Equals(t.Name,"TestModule",StringComparison.Ordinal));

            Assert.Contains(_moduleManager.GetFeatures(), t => string.Equals(t.Id, "TestModule.Feature1", StringComparison.Ordinal));
        }


        [Fact]
        public void ShouldReturnFeatureDenpendenciesWithAppointOrder()
        {

            var featureDenpendcies = _moduleManager.GetDependentFeatures("TestModule.Feature1");

            Assert.Equal(3, featureDenpendcies.Count());
            Assert.Equal("TestModule.Feature1", featureDenpendcies.ElementAt(0).Id);
            Assert.Equal("TestModule.Feature2", featureDenpendcies.ElementAt(1).Id);
            Assert.Equal("TestModule.Feature3", featureDenpendcies.ElementAt(2).Id);


            featureDenpendcies = _moduleManager.GetDependentFeatures("TestModule.Feature2");

            Assert.Equal(2, featureDenpendcies.Count());
            Assert.Equal("TestModule.Feature2", featureDenpendcies.ElementAt(0).Id);
            Assert.Equal("TestModule.Feature3", featureDenpendcies.ElementAt(1).Id);
        }


        [Fact]
        public void ShouldReturnNullFeatureAndNullModule()
        {
            var module = _moduleManager.GetModuleInfo("NullModule");
            Assert.True(module.IsNullObject());

            var feature = _moduleManager.GetFeature("NullFeature");
            Assert.True(feature.IsNullObject());
        }
    }

   
}