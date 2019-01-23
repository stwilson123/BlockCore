using System.Collections.Generic;
using System.Globalization;
using BlocksCore.Localization.Core;

namespace BlocksCore.Localization.Abstractions.Source
{
    public class LocalizationDictionary : ILocalizationDictionary
    {
        private readonly string _sourceName;
        
        public LocalizationDictionary(CultureInfo cultureInfo, string sourceName)
        {
            CultureInfo = cultureInfo;
            _sourceName = sourceName;
        }
        public CultureInfo CultureInfo { get; }
        
        
        public ModularLocalizedString GetOrNull(string name)
        {
             return new ModularLocalizedString(_sourceName,name);
        }

        public ModularLocalizedString GetOrNull(string name, params object[] value)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<ModularLocalizedString> GetAllStrings()
        {
            throw new System.NotImplementedException();
        }

        public ILocalizationDictionary Merge(ILocalizationDictionary other)
        {
            if (other == null)
                return this;
            
            
            
            return this;
        }
    }
}