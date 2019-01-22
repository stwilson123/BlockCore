using System.Collections.Generic;

namespace BlocksCore.Navigation.Abstractions
{
    public interface INavigation
    {
        /// <summary>
        /// Unique name of the menu item in the application. 
        /// Can be used to find this menu item later.
        /// </summary>
        string Name { get; }

        //string ExtensionName { get; set; }


        IDictionary<string, object> RouteValues { get; }
    }
}
