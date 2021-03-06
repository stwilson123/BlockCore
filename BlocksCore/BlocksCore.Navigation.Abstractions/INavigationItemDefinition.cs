﻿using BlocksCore.Abstractions.Security.Authorization;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Navigation.Abstractions
{
    public interface INavigationItemDefinition : INavigation
    {

        /// <summary>
        /// Display name of the menu item. Required.
        /// </summary>
        LocalizedString DisplayName { get; }
 

//        /// <summary>
//        /// A feature dependency.
//        /// Optional.
//        /// </summary>
//        IFeatureDependency FeatureDependency { get; }
//        IPermissionDependency PermissionDependency { get;  }
        /// <summary>
        /// This can be set to true if only authenticated users should see this menu item.
        /// </summary>
        bool RequiresAuthentication { get; }

        Permission[]  HasPermissions { get; }

//        /// <summary>
//        /// Returns true if this menu item has no child <see cref="Items"/>.
//        /// </summary>
//        bool IsLeaf { get; }

        /// <summary>
        /// Can be used to store a custom object related to this menu item. Optional.
        /// </summary>
        object CustomData { get; }

        /// <summary>
        /// Can be used to show/hide a menu item.
        /// </summary>
        bool IsVisible { get; set; }

//        /// <summary>
//        /// Sub items of this menu item. Optional.
//        /// </summary>
//        IList<INavigationItemDefinition> Items { get; }
//
//        /// <summary>
//        /// Adds a <see cref="NavigationItemDefinition"/> to <see cref="NavigationItemDefinition.Items"/>.
//        /// </summary>
//        /// <param name="navItem"><see cref="NavigationItemDefinition"/> to be added</param>
//        /// <returns>This <see cref="NavigationItemDefinition"/> object</returns>
//        INavigationItemDefinition AddItem(INavigationItemDefinition navItem);
    }
}