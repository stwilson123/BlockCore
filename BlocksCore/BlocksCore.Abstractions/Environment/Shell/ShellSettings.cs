using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Shell
{
    public class ShellSettings
    {
        public const string DefaultShellName = "Default";
        public string Name
        {
            get;
            set;
        }
        public TenantState State
        {
            get;
            set;
        }

        public static ShellSettings  CreateDefaultUninitialized()
        {
            return new ShellSettings() { Name = DefaultShellName, State = TenantState.Uninitialized };
        }
    }
}
