﻿using System.Collections.Generic;

namespace BlocksCore.Navigation.Abstractions.Manager
{
    /// <summary>
    /// Manages navigation in the application.
    /// </summary>
    public interface INavigationManager  
    {
        /// <summary>
        /// All menus defined in the application.
        /// </summary>
        IDictionary<string, INavigationDefinition> Menus { get; }

        /// <summary>
        /// Gets the main menu of the application.
        /// A shortcut of <see cref="Menus"/>["MainMenu"].
        /// </summary>
        INavigationDefinition MainMenu { get; }

        
        void Initialize();
    }
}