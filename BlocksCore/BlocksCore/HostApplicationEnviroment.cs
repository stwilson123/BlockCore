using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.Modules.ModuleDescription;
using Microsoft.AspNetCore.Hosting;

namespace BlocksCore
{
    public class HostApplicationEnviroment : IHostApplicationEnviroment
    {
        private IHostingEnvironment _hostingEnvironment;

        private Assembly Assembly;
        public HostApplicationEnviroment(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            Assembly = Assembly.Load(new AssemblyName(ApplicationName));

            ModuleNames = Assembly.GetCustomAttributes<ModuleAttribute>().Select(m => m.Name).ToList();

        }
        public string EnvironmentName
        {
            get
            {
                return _hostingEnvironment.EnvironmentName;
            }
        }
        public string ApplicationName
        {
            get
            {
                return _hostingEnvironment.ApplicationName;
                
            }
        }

        public IEnumerable<string> ModuleNames { get; }
    }
}