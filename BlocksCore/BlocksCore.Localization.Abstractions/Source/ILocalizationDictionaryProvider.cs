using System.Threading.Tasks;

namespace BlocksCore.Localization.Abstractions.Source
{
    public interface ILocalizationDictionaryProvider
    {
        Task<ILocalizationDictionary> GetLocalizationDictionary(string sourceName,string culture);
    }
}