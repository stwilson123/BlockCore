using BlocksCore.Navigation.Abstractions.Manager;
using BlocksCore.Navigation.Abstractions.Provider;

namespace BlocksCore.Navigation.Provider
{
    internal class NavigationProviderContext : INavigationProviderContext
    {
        public INavigationManager Manager { get; internal set; }
        
        public NavigationProviderContext(INavigationManager manager)
        {
            Manager = manager;
        }
    }
}