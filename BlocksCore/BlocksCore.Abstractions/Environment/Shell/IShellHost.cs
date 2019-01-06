using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlocksCore.Abstractions.Shell
{
    public interface IShellHost
    {
        Task InitializeAsync();

    }
}
