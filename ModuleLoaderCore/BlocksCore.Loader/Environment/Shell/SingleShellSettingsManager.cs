using System.Collections.Generic;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Shell.Models;

namespace BlocksCore.Loader.Environment.Shell
{
    public class SingleShellSettingsManager : IShellSettingsManager
    {
        public IEnumerable<ShellSettings> LoadSettings()
        {
            yield return new ShellSettings
            {
                Name = "Default",
                State = TenantState.Running
            };
        }

        public void SaveSettings(ShellSettings shellSettings)
        {
        }
    }
}