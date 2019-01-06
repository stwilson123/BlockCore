using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BlocksCore.Abstractions.Shell.Builders.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Abstractions.Shell
{
    public class ShellContext : IDisposable
    {
        public ShellSettings Settings { get; set; }
        public ShellBlueprint Blueprint { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        
        private bool _released = false;
        private volatile int _refCount = 0;

        
        /// <summary>
        /// Whether the <see cref="ShellContext"/> instance has been released, for instance when a tenant is changed.
        /// </summary>
        public bool Released => _released;
        
        public IServiceScope CreateScope()
        {
            var scope = new ServiceScopeWrapper(this);

            // A new scope can be only used on a non released shell.
            if (!_released)
            {
                return scope;
            }

            (scope as ServiceScopeWrapper).Dispose();

            return null;
            
            
            
        }
        public void Dispose()
        {
             
        }


         internal class ServiceScopeWrapper : IServiceScope
        {
            private readonly ShellContext _shellContext;
            private readonly IServiceScope _serviceScope;
            private readonly IServiceProvider _existingServices;
            private readonly HttpContext _httpContext;

            public ServiceScopeWrapper(ShellContext shellContext)
            {
                // Prevent the context from being disposed until the end of the scope
                Interlocked.Increment(ref shellContext._refCount);

                _shellContext = shellContext;

                // The service provider is null if we try to create
                // a scope on a disabled shell or already disposed.
                if (_shellContext.ServiceProvider == null)
                {
                    throw new ArgumentNullException(nameof(shellContext.ServiceProvider), $"Can't resolve a scope on tenant: {shellContext.Settings.Name}");
                }

                _serviceScope = shellContext.ServiceProvider.CreateScope();
                ServiceProvider = _serviceScope.ServiceProvider;

                var httpContextAccessor = ServiceProvider.GetRequiredService<IHttpContextAccessor>();

                _httpContext = httpContextAccessor.HttpContext;
                _existingServices = _httpContext.RequestServices;
                _httpContext.RequestServices = ServiceProvider;
            }

            public IServiceProvider ServiceProvider { get; }

            /// <summary>
            /// Returns true if the shell context should be disposed consequently to this scope being released.
            /// </summary>
            private bool ScopeReleased()
            {
                // A disabled shell still in use is released by its last scope.
                if (_shellContext.Settings.State == TenantState.Disabled)
                {
                    if (Interlocked.CompareExchange(ref _shellContext._refCount, 1, 1) == 1)
                    {
                        _shellContext.Release();
                    }
                }

                // If the context is still being released, it will be disposed if the ref counter is equal to 0.
                // To prevent this while executing the terminating events, the ref counter is not decremented here.
                if (_shellContext._released && Interlocked.CompareExchange(ref _shellContext._refCount, 1, 1) == 1)
                {
                    var tenantEvents = _serviceScope.ServiceProvider.GetServices<IModularTenantEvents>();

                    foreach (var tenantEvent in tenantEvents)
                    {
                        tenantEvent.TerminatingAsync().GetAwaiter().GetResult();
                    }

                    foreach (var tenantEvent in tenantEvents.Reverse())
                    {
                        tenantEvent.TerminatedAsync().GetAwaiter().GetResult();
                    }

                    return true;
                }

                return false;
            }

            public void Dispose()
            {
                var disposeShellContext = ScopeReleased();

                _httpContext.RequestServices = _existingServices;
                _serviceScope.Dispose();

                if (disposeShellContext)
                {
                    _shellContext.Dispose();
                }

                // Decrement the counter at the very end of the scope
                Interlocked.Decrement(ref _shellContext._refCount);
            }
        }
    }
}
