using System.Threading.Tasks;

namespace BlocksCore.Loader.Abstractions.Modules.Services
{
    /// <summary>
    /// Provides the timezone for the current request.
    /// </summary>
    public interface ITimeZoneSelector
    {
        Task<TimeZoneSelectorResult> GetTimeZoneAsync();
    }
}
