using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using BlocksCore.Localization.Abstractions.Source;

namespace BlocksCore.Localization.Abstractions
{
    public interface ILocalizationManager
    {
        ILocalizationDictionary GetDictionary(string sourceName,CultureInfo culture);

    }
}
