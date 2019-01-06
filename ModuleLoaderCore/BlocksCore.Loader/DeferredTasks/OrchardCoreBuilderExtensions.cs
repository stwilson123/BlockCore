using BlocksCore.Loader.Abstractions.DeferredTasks;
using BlocksCore.Loader.Abstractions.Modules.Builder;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlocksCore.Loader.DeferredTasks
{
    public static partial class BlocksCoreBuilderExtensions
    {
        /// <summary>
        /// Adds tenant level deferred tasks services.
        /// </summary>
        public static BlocksCoreBuilder AddDeferredTasks(this BlocksCoreBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.TryAddScoped<IDeferredTaskEngine, DeferredTaskEngine>();
                services.TryAddScoped<IDeferredTaskState, HttpContextTaskState>();
            });

            return builder;
        }
    }
}
