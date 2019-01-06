using BlocksCore.Loader.Abstractions.Shell.Models;

namespace BlocksCore.Loader.Abstractions.Shell.Extensions
{
    public static class ShellHelper
    {
        public const string DefaultShellName = "Default";

        public static ShellSettings BuildDefaultUninitializedShell = new ShellSettings {
            Name = DefaultShellName,
            State = TenantState.Uninitialized
        };
    }
}