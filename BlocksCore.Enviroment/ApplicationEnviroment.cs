using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlocksCore.Module.Abstractions.ModuleDescription;
using Microsoft.AspNetCore.Hosting;

namespace BlocksCore.Enviroment
{
    public class ApplicationEnviroment : IApplicationEnviroment
    {
        private IHostingEnvironment _hostingEnvironment;

        private Assembly Assembly;
        public ApplicationEnviroment(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            Assembly = Assembly.Load(new AssemblyName(ApplicationName));

            ModuleDescriptions = Assembly.GetCustomAttributes<ModuleAttribute>();

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

        public IEnumerable<ModuleAttribute> ModuleDescriptions { get; }
    }
}