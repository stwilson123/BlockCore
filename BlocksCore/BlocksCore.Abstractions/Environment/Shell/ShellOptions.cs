﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Shell
{
    public class ShellOptions
    {
        /// <summary>
        /// The root container
        /// </summary>
        public string ShellsApplicationDataPath { get; set; }

        /// <summary>
        /// The container for shells
        /// </summary>
        public string ShellsContainerName { get; set; }
    }
}
