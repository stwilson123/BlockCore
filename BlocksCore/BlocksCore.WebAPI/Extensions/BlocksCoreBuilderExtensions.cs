using BlocksCore.Loader.Abstractions.Modules.Builder;

namespace BlocksCore.WebAPI.Extensions
{
    public static class BlocksCoreBuilderExtensions
    {
        /// <summary>
        /// Adds tenant level MVC services and configuration.
        /// </summary>
        public static BlocksCoreBuilder AddWebApi(this BlocksCoreBuilder builder)
        {
            return builder.RegisterStartup<Startup>();
        }
    }
}