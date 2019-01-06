using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlocksCore.Loader.Abstractions.BackgroundTasks
{
    public interface IBackgroundTask
    {
        Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);
    }
}
