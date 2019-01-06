using System;
using BlocksCore.Loader.Abstractions.Shell.Builders.Models;

namespace BlocksCore.Loader.Abstractions.Shell.Builders
{
    public interface IShellContainerFactory
    {
        IServiceProvider CreateContainer(ShellSettings settings, ShellBlueprint blueprint);
    }
}