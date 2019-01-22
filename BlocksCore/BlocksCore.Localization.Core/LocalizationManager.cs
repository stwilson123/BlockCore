using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlocksCore.Localization.Abstractions;
using BlocksCore.Localization.Abstractions.Source;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Localization.Core
{
    public class LocalizationManager : ILocalizationManager
    {
        private readonly IMemoryCache _cache;
        private readonly IEnumerable<ILocalizationDictionaryProvider> _localizationDictionaryProviders;
        private const string CacheKeyPrefix = "CultureDictionary-{0}-{1}";

        public LocalizationManager(IMemoryCache cache,IEnumerable<ILocalizationDictionaryProvider> localizationDictionaryProviders)
        {
            _cache = cache;
            _localizationDictionaryProviders = localizationDictionaryProviders;
        }


        public ILocalizationDictionary GetDictionary(CultureInfo culture)
        {
            var sourceName = "";
            var cachedDictionary = _cache.GetOrCreate(string.Format(CacheKeyPrefix, sourceName, culture.Name), k => new Lazy<ILocalizationDictionary>(() =>
            {
                LocalizationDictionary dic = new LocalizationDictionary();
                var localizationDictionaries = Task.WhenAll(_localizationDictionaryProviders
                    .Select(t => t.GetLocalizationDictionary(sourceName, culture.Name))).Result;
                
                foreach (var localizationDictionary in localizationDictionaries)
                {
                    dic.Merge(localizationDictionary);
                }
                return dic;
            }, LazyThreadSafetyMode.ExecutionAndPublication));
            return cachedDictionary.Value;
        }
        
        
        
        
    }
}