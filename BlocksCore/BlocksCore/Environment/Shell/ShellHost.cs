using BlocksCore.Abstractions.Environment.Shell;
using BlocksCore.Abstractions.Extensions;
using BlocksCore.Abstractions.Shell;
using BlocksCore.Abstractions.Shell.Builders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlocksCore.Shell
{
    public class ShellHost : IShellHost
    {
        private bool _initialized;
        private SemaphoreSlim _initializingSemaphore = new SemaphoreSlim(1);
        private readonly ConcurrentDictionary<string, SemaphoreSlim> _shellSemaphores = new ConcurrentDictionary<string, SemaphoreSlim>();

        private ConcurrentDictionary<string, ShellContext> _shellContexts;
        private readonly IModuleManager _extensionManager;
        private readonly IShellContextFactory _shellContextFactory;
        private readonly IShellSettingsManager _shellSettingsManager;

        public ShellHost(IModuleManager extensionManager,IShellContextFactory shellContextFactory, IShellSettingsManager shellSettingsManager)
        {
            _extensionManager = extensionManager;
            _shellContextFactory = shellContextFactory;
            _shellSettingsManager = shellSettingsManager;
        }

        public async Task InitializeAsync()
        {
            if (!_initialized)
            {
                try
                {
                    // Prevent concurrent requests from creating all shells multiple times
                    await _initializingSemaphore.WaitAsync();

                    if (!_initialized)
                    {
                        _shellContexts = new ConcurrentDictionary<string, ShellContext>();
                        await CreateAndRegisterShellsAsync();
                    }
                }
                finally
                {
                    _initialized = true;
                    _initializingSemaphore.Release();
                }
            }
        }
        async Task CreateAndRegisterShellsAsync()
        {

            //TODO Log

            // Load all extensions and features so that the controllers are
            // registered in ITypeFeatureProvider and their areas defined in the application
            // conventions.
            var features = _extensionManager.LoadFeaturesAsync();
            
            
            var allSettings = _shellSettingsManager.LoadSettings().Where(CanCreateShell).ToArray();
            
            features.Wait();

            // No settings, run the Setup.
            if (allSettings.Length == 0)
            {
                var setupContext = await CreateSetupContextAsync();
               // AddAndRegisterShell(setupContext);
            }
            else
            {
                // Load all tenants, and activate their shell.
                await Task.WhenAll(allSettings.Select(async settings =>
                {
                    try
                    {
                        await GetOrCreateShellContextAsync(settings);
                    }
                    catch (System.Exception ex)
                    {
                      //  _logger.LogError(ex, "A tenant could not be started '{TenantName}'", settings.Name);
                      throw;
//                        if (ex.IsFatal())
//                        {
//                            throw;
//                        }
                    }
                }));
            }

//            if (_logger.IsEnabled(LogLevel.Information))
//            {
//                _logger.LogInformation("Done creating shells");
//            }
            
        }


    
        public async Task<ShellContext> GetOrCreateShellContextAsync(ShellSettings settings)
        {
            ShellContext shell = null;

            while (shell == null)
            {
                if (!_shellContexts.TryGetValue(settings.Name, out shell))
                {
                    var semaphore = _shellSemaphores.GetOrAdd(settings.Name, (name) => new SemaphoreSlim(1));

                    await semaphore.WaitAsync();

                    try
                    {
                        if (!_shellContexts.TryGetValue(settings.Name, out shell))
                        {
                            shell = await CreateShellContextAsync(settings);
                            RegisterShell(shell);

                            _shellContexts.TryAdd(settings.Name, shell);
                        }

                    }
                    finally
                    {
                        semaphore.Release();
                        _shellSemaphores.TryRemove(settings.Name, out semaphore);
                    }
                }

                if (shell.Released)
                {
                    // If the context is released, it is removed from the dictionary so that
                    // a new call on 'GetOrCreateShellContextAsync' will recreate a new shell context.
                    _shellContexts.TryRemove(settings.Name, out var value);
                    shell = null;
                }
            }

            return shell;
        }
        
        /// <summary>
        /// Creates a shell context based on shell settings
        /// </summary>
        public Task<ShellContext> CreateShellContextAsync(ShellSettings settings)
        {
//            if (settings.State == TenantState.Uninitialized)
               //            {
               ////                if (_logger.IsEnabled(LogLevel.Debug))
               ////                {
               ////                    _logger.LogDebug("Creating shell context for tenant '{TenantName}' setup", settings.Name);
               ////                }
               //
               //                return _shellContextFactory.CreateSetupContextAsync(settings);
               //            }
               //            else if (settings.State == TenantState.Disabled)
               //            {
               //                if (_logger.IsEnabled(LogLevel.Debug))
               //                {
               //                    _logger.LogDebug("Creating disabled shell context for tenant '{TenantName}'", settings.Name);
               //                }
               //
               //                return Task.FromResult(new ShellContext { Settings = settings });
               //            }
            if (settings.State == TenantState.Running || settings.State == TenantState.Initializing)
            {
//                if (_logger.IsEnabled(LogLevel.Debug))
//                {
//                    _logger.LogDebug("Creating shell context for tenant '{TenantName}'", settings.Name);
//                }

                return _shellContextFactory.CreateShellContextAsync(settings);
            }
            else
            {
                throw new InvalidOperationException("Unexpected shell state for " + settings.Name);
            }
            
            
            
        }
        /// <summary>
        /// Whether or not a shell can be added to the list of available shells.
        /// </summary>
        private bool CanCreateShell(ShellSettings shellSettings)
        {
            return
                shellSettings.State == TenantState.Running ||
                shellSettings.State == TenantState.Uninitialized ||
                shellSettings.State == TenantState.Initializing ||
                shellSettings.State == TenantState.Disabled;
        }
    }
}
