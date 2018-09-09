using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlocksCore.Enviroment;
using BlocksCore.Module.Abstractions.ModuleDescription;

namespace BlocksCore.Test.Stubs
{
    public class StubHostApplicationEnviroment : IHostApplicationEnviroment
    {
        
        public string EnvironmentName { get; }
        public string ApplicationName { get; }
        public IEnumerable<string> ModuleNames { get; }

        public StubHostApplicationEnviroment()
        {
            ApplicationName = this.GetType().Assembly.GetName().Name;
            
           var assembly = Assembly.Load(new AssemblyName(ApplicationName));

            ModuleNames = assembly.GetCustomAttributes<ModuleRegisterAttribute>().Select(m => m.Name).ToList();
        }
    }
}