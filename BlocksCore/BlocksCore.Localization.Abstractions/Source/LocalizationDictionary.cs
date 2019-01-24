using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BlocksCore.Localization.Core;
using Microsoft.Extensions.Localization;
using BlocksCore.SyntacticAbstractions.Types;
namespace BlocksCore.Localization.Abstractions.Source
{
    public class LocalizationDictionary : ILocalizationDictionary
    {
        public IDictionary<string, string> Translations { get; private set; }
        public CultureInfo CultureInfo { get; }
        public string SourceName { get; }
        
        public LocalizationDictionary(CultureInfo cultureInfo, string sourceName)
        {
         
            CultureInfo = cultureInfo;
            Translations = new Dictionary<string, string>();
            SourceName = sourceName;
           
        }
        public LocalizationDictionary(CultureInfo cultureInfo, string sourceName,IDictionary<string, string> translations)
        {
            CultureInfo = cultureInfo;
            Translations = translations;
            SourceName = sourceName;
           
        }



        public LocalizedString GetOrNull(string name)
        {
             return GetOrNull(name,null);
        }

        public LocalizedString GetOrNull(string name, params object[] param)
        {
            string value;
            if (!Translations.TryGetValue(name, out value))
            {
                return new LocalizedString(name,name);
            }
            
             return new LocalizedString(name, value.SafeFormat(param));
        }

        public IEnumerable<LocalizedString> GetAllStrings()
        {
            return Translations.Select(t => new LocalizedString(t.Key,t.Value));
        }

        public ILocalizationDictionary Merge(ILocalizationDictionary other)
        {
            if (other == null)
                return this;
            if(this.SourceName == other.SourceName && this.CultureInfo.Name == other.CultureInfo?.Name)
            {
                foreach (var translationKv in other.Translations)
                {
                    if (this.Translations.ContainsKey(translationKv.Key))
                        this.Translations[translationKv.Key] = translationKv.Value;
                    else
                    {
                        this.Translations.Add(translationKv.Key,translationKv.Value);
                    }
                }
            }  
                
            return this;
        }
    }
}