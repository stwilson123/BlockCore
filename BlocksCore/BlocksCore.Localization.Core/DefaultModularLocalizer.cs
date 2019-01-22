using System.Collections.Generic;
using System.Globalization;
using BlocksCore.Localization.Abstractions;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Localization.Core
{
    public class DefaultModularLocalizer : IModularLocalizer
    {
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new System.NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }

        public LocalizedString this[string name] => throw new System.NotImplementedException();

        public LocalizedString this[string name, params object[] arguments] => throw new System.NotImplementedException();
    }
}