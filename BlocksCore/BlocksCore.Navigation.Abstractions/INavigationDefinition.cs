using System.Collections.Generic;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Navigation.Abstractions
{
    public interface INavigationDefinition
    {
        /// <summary>
        /// Unique name of the navigation in the application. Required.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Display name of the menu. Required.
        /// </summary>
        LocalizedString DisplayName { get; set; }

        /// <summary>
        /// Can be used to store a custom object related to this menu. Optional.
        /// </summary>
        object CustomData { get; set; }

        /// <summary>
        /// Navigation items (first level).
        /// </summary>
        IList<INavigationItemDefinition> Items { get; set; }

        INavigationDefinition AddItem(INavigationItemDefinition navItem);

    }
}