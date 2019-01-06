using BlocksCore.Abstractions.Shell;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Environment.Shell
{
    public interface IShellSettingsManager
    {
        /// <summary>
        /// Retrieves all shell settings stored.
        /// </summary>
        /// <returns>All shell settings.</returns>
        IEnumerable<ShellSettings> LoadSettings();
    }
}
