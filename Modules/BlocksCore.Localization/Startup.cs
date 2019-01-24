using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Localization.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlocksCore.Localization
{
    public class Startup : StartupBase
    {

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalizationCore();
        }
    }
}