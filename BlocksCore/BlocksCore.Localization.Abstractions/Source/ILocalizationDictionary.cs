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
        /// Gets/sets a string for this dictionary with given name (key).
        /// </summary>
        /// <param name="name">Name to get/set</param>
        string this[string name] { get; set; }

        /// <summary>
        /// Gets a <see cref="LocalizedString"/> for given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name (key) to get localized string</param>
        /// <returns>The localized string or null if not found in this dictionary</returns>
        ModularLocalizedString GetOrNull(string name);

        /// <summary>
        /// Gets a list of all strings in this dictionary.
        /// </summary>
        /// <returns>List of all <see cref="LocalizedString"/> object</returns>
        IReadOnlyList<ModularLocalizedString> GetAllStrings();

        ILocalizationDictionary Merge(ILocalizationDictionary other);
    }
}