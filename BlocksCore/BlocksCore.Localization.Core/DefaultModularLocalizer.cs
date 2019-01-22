using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private readonly ILocalizationDictionary _localizationDictionary;

        public DefaultModularLocalizer(CultureInfo culture, ILocalizationManager localizationManager, ILocalizationDictionary localizationDictionary)
        {
            _localizationManager = localizationManager;
            _localizationDictionary = localizationDictionary;

//            _localizationDictionary = _localizationManager.GetDictionary(
//                culture,shellHost.ListShellContextsAsync().Result.SelectMany(t => t.Blueprint.Dependencies)[typeof(T)])
//            
//            
//            );
        }
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
           
            throw new System.NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new DefaultModularLocalizer<T>(culture,  _localizationManager,_localizationDictionary);
        }

        public LocalizedString this[string name] => throw new System.NotImplementedException();

        public LocalizedString this[string name, params object[] arguments] => throw new System.NotImplementedException();
    }
}