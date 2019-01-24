using System;
using System.Globalization;
using BlocksCore.Abstractions.Shell;
using BlocksCore.Localization.Abstractions;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Localization.Core
{
    public class DefaultModularLocalizerFactory: IStringLocalizerFactory
    {
        private readonly ILocalizationManager _localizationManager;
        private readonly ITenantShellManager _tenantShellManager;

        public DefaultModularLocalizerFactory(ILocalizationManager localizationManager,ITenantShellManager tenantShellManager)
        {
            _localizationManager = localizationManager;
            _tenantShellManager = tenantShellManager;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new DefaultModularLocalizer(CultureInfo.CurrentUICulture,_localizationManager, _tenantShellManager,resourceSource);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            throw new NotImplementedException();
        }
    }
}