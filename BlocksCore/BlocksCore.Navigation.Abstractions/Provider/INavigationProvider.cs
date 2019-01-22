namespace BlocksCore.Navigation.Abstractions.Provider
{
    
    /// <summary>
    /// This interface should be implemented by classes which change
    /// navigation of the application.
    /// </summary>
    public interface INavigationProvider  
    {

        /// <summary>
        /// Used to set navigation.
        /// </summary>
        /// <param name="context">Navigation context</param>
         void SetNavigation(INavigationProviderContext context);
    }
}