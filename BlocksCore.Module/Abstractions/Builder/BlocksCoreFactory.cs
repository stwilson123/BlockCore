using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Module.Abstractions.Builder
{
    public class BlocksCoreFactory
    {
        
        public static BlocksCoreBuilder AddBlocksCoreBuilder(IServiceCollection serviceCollection)
        {
            
            var builder = serviceCollection.LastOrDefault(s => s.ServiceType == typeof(BlocksCoreBuilder))?
                .ImplementationInstance as BlocksCoreBuilder;
            
            
            
            if (builder == null)
            {
                builder = new BlocksCoreBuilder(serviceCollection);
                serviceCollection.AddSingleton(builder);
            }
            

            
            return builder;
        }
    }
}