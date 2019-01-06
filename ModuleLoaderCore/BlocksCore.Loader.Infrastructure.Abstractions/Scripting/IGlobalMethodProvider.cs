﻿using System.Collections.Generic;

namespace BlocksCore.Infrastructure.Scripting
{
    /// <summary>
    /// An implementation of <see cref="IGlobalMethodProvider"/> provides custom methods for
    /// an <see cref="IScriptingManager"/> intance.
    /// </summary>
    public interface IGlobalMethodProvider
    {
        /// <summary>
        /// Gets the list of methods to provide to the <see cref="IScriptingManager"/>.
        /// </summary>
        /// <returns>A list of <see cref="GlobalMethod"/> instances.</returns>
        IEnumerable<GlobalMethod> GetMethods();
    }
}
