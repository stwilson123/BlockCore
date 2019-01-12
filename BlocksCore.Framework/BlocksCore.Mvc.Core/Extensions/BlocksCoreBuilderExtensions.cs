using BlocksCore.Loader.Abstractions.Modules.Builder;

namespace BlocksCore.Mvc.Core.Extensions
{
    public static class BlocksCoreBuilderExtensions
    {
        /// <summary>
        /// Adds tenant level MVC services and configuration.
        /// </summary>
        public static BlocksCoreBuilder AddMvc(this BlocksCoreBuilder builder)
        {
            return builder.RegisterStartup<Startup>();
        }
    }
}