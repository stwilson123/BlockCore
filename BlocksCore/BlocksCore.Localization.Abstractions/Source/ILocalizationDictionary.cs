using System.Collections.Generic;
using System.Globalization;
using BlocksCore.Localization.Core;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Localization.Abstractions.Source
{
    public interface ILocalizationDictionary
    {
        /// <summary>
        /// Culture of the dictionary.
        /// </summary>
        CultureInfo CultureInfo { get; }
        
 
        /// <summary>
        /// Gets a <see cref="LocalizedString"/> for given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name (key) to get localized string</param>
        /// <returns>The localized string or null if not found in this dictionary</returns>
        ModularLocalizedString GetOrNull(string name);

        
        /// <summary>
        /// Gets a <see cref="LocalizedString"/> for given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name (key) to get localized string</param>
        /// <returns>The localized string or null if not found in this dictionary</returns>
        ModularLocalizedString GetOrNull(string name,params object[] value);
        
        /// <summary>
        /// Gets a list of all strings in this dictionary.
        /// </summary>
        /// <returns>List of all <see cref="LocalizedString"/> object</returns>
        IReadOnlyList<ModularLocalizedString> GetAllStrings();

        ILocalizationDictionary Merge(ILocalizationDictionary other);
    }
}