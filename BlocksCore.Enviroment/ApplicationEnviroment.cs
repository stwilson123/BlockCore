using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

namespace BlocksCore.Enviroment
{
    public class ApplicationEnviroment : IApplicationEnviroment
    {
        private IHostingEnvironment _hostingEnvironment;
        public ApplicationEnviroment(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            
            
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