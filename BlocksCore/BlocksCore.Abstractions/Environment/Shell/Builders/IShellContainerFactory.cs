using System;
using System.Collections.Generic;
using System.Text;
using BlocksCore.Abstractions.Shell.Builders.Models;

namespace BlocksCore.Abstractions.Shell.Builders
{
    public interface IShellContainerFactory
    {
        
        IServiceProvider CreateContainer(ShellSettings settings, ShellBlueprint blueprint);
    }
}
