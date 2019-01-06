using BlocksCore.Loader.Infrastructure.Entities.Scripting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BlocksCore.Infrastructure.Entities;
using BlocksCore.Infrastructure.Scripting;

namespace BlocksCore.Loader.Infrastructure.Entities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdGeneration(this IServiceCollection services)
        {
            services.TryAddSingleton<IIdGenerator, DefaultIdGenerator>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IGlobalMethodProvider, IdGeneratorMethod>());
            return services;
        }
    }
}
