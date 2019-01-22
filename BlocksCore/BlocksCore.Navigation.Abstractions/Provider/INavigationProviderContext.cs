using INavigationManager = BlocksCore.Navigation.Abstractions.Manager.INavigationManager;

namespace BlocksCore.Navigation.Abstractions.Provider
{
    public interface INavigationProviderContext  
    {
        /// <summary>
        /// Gets a reference to the navigation manager.
        /// </summary>
        INavigationManager Manager { get; }
    }
 
}