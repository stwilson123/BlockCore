using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlocksCore.Abstractions.Shell.Builders
{
    public interface IShellContextFactory
    {

        Task<ShellContext> CreateSetupContextAsync(ShellSettings settings);

        Task<ShellContext> CreateShellContextAsync(ShellSettings settings);
    }
}
