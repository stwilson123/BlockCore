using BlocksCore.Loader.Abstractions;
using BlocksCore.Loader.Abstractions.Modules.Builder;
using BlocksCore.Loader.Infrastructure.Cache.CacheContextProviders;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using BlocksCore.Infrastructure.Cache;

namespace BlocksCore.Loader.Infrastructure.Cache
{
    public static partial class BlocksCoreBuilderExtensions
    {
        /// <summary>
        /// Adds tenant level caching services.
        /// </summary>
        public static BlocksCoreBuilder AddCaching(this BlocksCoreBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddTransient<ITagCache, DefaultTagCache>();
                services.AddSingleton<ISignal, Signal>();
                services.AddScoped<ICacheContextManager, CacheContextManager>();
                services.AddScoped<ICacheScopeManager, CacheScopeManager>();

                services.AddScoped<ICacheContextProvider, FeaturesCacheContextProvider>();
                services.AddScoped<ICacheContextProvider, QueryCacheContextProvider>();
                services.AddScoped<ICacheContextProvider, RolesCacheContextProvider>();
                services.AddScoped<ICacheContextProvider, RouteCacheContextProvider>();
                services.AddScoped<ICacheContextProvider, UserCacheContextProvider>();
                services.AddScoped<ICacheContextProvider, KnownValueCacheContextProvider>();

                // IMemoryCache is registered at the tenant level so that there is one instance for each tenant.
                services.AddSingleton<IMemoryCache, MemoryCache>();

                // MemoryDistributedCache needs to be registered as a singleton as it owns a MemoryCache instance.
                services.AddSingleton<IDistributedCache, MemoryDistributedCache>();
            });

            return builder;
        }
    }
}
