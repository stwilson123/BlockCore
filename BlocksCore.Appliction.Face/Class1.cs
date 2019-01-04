using System;
using BlocksCore.Abstractions.Modules.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Appliction.Face
{
    public static class ServiceExtensions
    { 
        public static void AddBlocksCore(this IServiceCollection services)
        {
              AddBlocksCore(services, null);
        }

        public static void AddBlocksCore(this IServiceCollection services,Action<BlocksCoreBuilder> configAction)
        {

            var builder = BlocksCoreFactory.AddBlocksCoreBuilder(services);

            
            configAction?.Invoke(builder);
        }
 
    }
}