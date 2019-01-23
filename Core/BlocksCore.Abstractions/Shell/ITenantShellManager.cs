using BlocksCore.Loader.Abstractions.Shell.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Shell
{
    public interface ITenantShellManager
    {
        ShellContext GetCurrentTenantShellContext();
    }
}
