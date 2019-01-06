using BlocksCore.Abstractions.Shell;
using BlocksCore.Abstractions.Shell.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlocksCore.Abstractions.Environment.Shell.Descriptor;
using BlocksCore.Abstractions.Environment.Shell.Descriptor.Models;

namespace BlocksCore.Shell.Builders
{
    class ShellContextFactory : IShellContextFactory
    {
        
        private readonly ICompositionStrategy _compositionStrategy;
        private readonly IShellContainerFactory _shellContainerFactory;

        public ShellContextFactory(IShellContainerFactory shellContainerFactory, ICompositionStrategy compositionStrategy)
        {
            _shellContainerFactory = shellContainerFactory;
            _compositionStrategy = compositionStrategy;
        }


        public Task<ShellContext> CreateSetupContextAsync(ShellSettings settings)
        {
            throw new NotImplementedException();
        }

        public Task<ShellContext> CreateShellContextAsync(ShellSettings settings)
        {
//            if (_logger.IsEnabled(LogLevel.Information))
//            {
//                _logger.LogInformation("Creating shell context for tenant '{TenantName}'", settings.Name);
//            }

            var describedContext = await CreateDescribedContextAsync(settings, MinimumShellDescriptor());

            ShellDescriptor currentDescriptor;
            using (var scope = describedContext.CreateScope())
            {
                var shellDescriptorManager = scope.ServiceProvider.GetService<IShellDescriptorManager>();
                currentDescriptor = await shellDescriptorManager.GetShellDescriptorAsync();
            }

            if (currentDescriptor != null)
            {
                describedContext.Release();
                return await CreateDescribedContextAsync(settings, currentDescriptor);
            }

            return describedContext;
        }
        
        public async Task<ShellContext> CreateDescribedContextAsync(ShellSettings settings, ShellDescriptor shellDescriptor)
        {
//            if (_logger.IsEnabled(LogLevel.Debug))
//            {
//                _logger.LogDebug("Creating described context for tenant '{TenantName}'", settings.Name);
//            }

            var blueprint = await _compositionStrategy.ComposeAsync(settings, shellDescriptor);
            var provider = _shellContainerFactory.CreateContainer(settings, blueprint);

            return new ShellContext
            {
                Settings = settings,
                Blueprint = blueprint,
                ServiceProvider = provider
            };
        }
    }
}
