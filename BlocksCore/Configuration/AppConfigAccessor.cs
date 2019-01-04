using BlocksCore.Abstractions.Configuration;
using Microsoft.Extensions.Configuration;

namespace BlocksCore.Configuration
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
