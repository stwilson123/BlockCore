﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BlocksCore.Loader.Abstractions.Modules.Exceptions
{
    public static class ExceptionExtensions
    {
        public static bool IsFatal(this Exception ex)
        {
            return 
                ex is OutOfMemoryException ||
                ex is SecurityException ||
                ex is SEHException;
        }
    }
}