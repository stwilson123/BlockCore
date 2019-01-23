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
    public class DefaultModularLocalizer<T> : IModularLocalizer<T>
    {
        private readonly ILocalizationManager _localizationManager;
        private readonly ITenantShellManager _tenantShellManager;
        private readonly ILocalizationDictionary _localizationDictionary;

        public DefaultModularLocalizer(CultureInfo culture, ILocalizationManager localizationManager, 
            ITenantShellManager tenantShellManager)
        {
            _localizationManager = localizationManager;
            _tenantShellManager = tenantShellManager;

            var feature = _tenantShellManager.GetCurrentTenantShellContext().Blueprint.Dependencies[typeof(T)];
            _localizationDictionary = _localizationManager.GetDictionary(feature.FeatureInfo.Id,culture);
        }
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {

            return _localizationDictionary.GetAllStrings();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new DefaultModularLocalizer<T>(culture,  _localizationManager,_tenantShellManager);
        }

        public LocalizedString this[string name] => _localizationDictionary.GetOrNull(name);

        public LocalizedString this[string name, params object[] arguments] => _localizationDictionary.GetOrNull(name,arguments);
    }
}