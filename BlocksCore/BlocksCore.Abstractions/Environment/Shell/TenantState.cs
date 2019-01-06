﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Shell
{
    public enum TenantState
    {
         /// <summary>
        /// The tenant is not yet intialized.
        /// </summary>
        Uninitialized,

        /// <summary>
        /// The tenant is being initialized.
        /// </summary>
        Initializing,

        /// <summary>
        /// The tenant is initialized and running.
        /// </summary>
        Running,

        /// <summary>
        /// The tenant is initialized and disabled.
        /// </summary>
        Disabled,

        /// <summary>
        /// The tenant settings are invalid.
        /// </summary>
        Invalid
    }
}