using System.Collections.Generic;
using BlocksCore.Enviroment;
using BlocksCore.Enviroment.Extensions;
using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Module.Abstractions.ModuleDescription;
using BlocksCore.Test.Stubs;
using Xunit;

namespace BlocksCore.Test.Enviroment.Extensions
{
    public class ModuleManagerTest
    {

        private IHostApplicationEnviroment _hostApplicationEnviroment = new StubHostApplicationEnviroment();
        private IModuleManager _moduleManager;
        public ModuleManagerTest()
        {
           _moduleManager = new ModuleManager(_hostApplicationEnviroment);
        }
        
        [Fact]
        public void ShouldReturnModuleAndFeatures()
        {

            _moduleManager.GetModuleInfos();
        }
    }

   
}