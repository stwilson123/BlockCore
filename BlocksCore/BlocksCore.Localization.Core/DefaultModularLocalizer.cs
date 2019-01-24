using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BlocksCore.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Localization.Abstractions;
using BlocksCore.Localization.Abstractions.Source;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Localization.Core
{
    public class DefaultModularLocalizer : IModularLocalizer
    {
        private readonly ILocalizationManager _localizationManager;
        private readonly ITenantShellManager _tenantShellManager;
        private readonly Type _localizer;
        private readonly ILocalizationDictionary _localizationDictionary;

        public DefaultModularLocalizer(CultureInfo culture, ILocalizationManager localizationManager, 
            ITenantShellManager tenantShellManager,Type localizer)
        {
            _localizationManager = localizationManager;
            _tenantShellManager = tenantShellManager;
            _localizer = localizer;

            var feature = _tenantShellManager.GetCurrentTenantShellContext().Blueprint.Dependencies[localizer];
            _localizationDictionary = _localizationManager.GetDictionary(feature.FeatureInfo.Id,culture);
        }
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {

            return _localizationDictionary.GetAllStrings();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new DefaultModularLocalizer(culture,  _localizationManager,_tenantShellManager,_localizer);
        }

        public LocalizedString this[string name] => _localizationDictionary.GetOrNull(name);

        public LocalizedString this[string name, params object[] arguments] => _localizationDictionary.GetOrNull(name,arguments);
    }

    
}