using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace BlocksCore.Loader.Abstractions.BackgroundTasks
{
    public interface IBackgroundTaskSettingsProvider
    {
        IChangeToken ChangeToken { get;  }
        Task<BackgroundTaskSettings> GetSettingsAsync(IBackgroundTask task);
    }
}