using System.Collections.Generic;
using System.Globalization;
using BlocksCore.Localization.Core;

namespace BlocksCore.Localization.Abstractions.Source
{
    public class LocalizationDictionary : ILocalizationDictionary
    {
        public CultureInfo CultureInfo { get; }

        public string this[string name]
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        public ModularLocalizedString GetOrNull(string name)
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<ModularLocalizedString> GetAllStrings()
        {
            throw new System.NotImplementedException();
        }

        public ILocalizationDictionary Merge(ILocalizationDictionary other)
        {
            throw new System.NotImplementedException();
        }
    }
}