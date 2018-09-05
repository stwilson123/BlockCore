using System;
using System.Collections.Generic;
using System.Text;
using BlocksCore.Enviroment.Configuration.Abstractions;
using Microsoft.Extensions.Configuration;

namespace BlocksCore.Enviroment.Configuration
{
    public class AppConfigAccessor : IAppConfigAccessor
    {
        public static string AppSettings = "AppSettings";
        private readonly IConfiguration _configuration;
        public AppConfigAccessor(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetSettings(string name)
        {
            return _configuration.GetSection(AppSettings)?.Value;
        }
    }
}
