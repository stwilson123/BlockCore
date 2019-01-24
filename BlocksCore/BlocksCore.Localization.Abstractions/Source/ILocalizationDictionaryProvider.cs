using System.Globalization;
using System.Threading.Tasks;

namespace BlocksCore.Localization.Abstractions.Source
{
    public interface ILocalizationDictionaryProvider
    {
        SourceType[] Sources { get; }

        Task<ILocalizationDictionary> GetLocalizationDictionary();
    }
}