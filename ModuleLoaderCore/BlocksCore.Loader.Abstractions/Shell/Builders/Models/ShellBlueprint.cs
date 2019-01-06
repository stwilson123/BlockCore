using System;
using System.Collections.Generic;
using BlocksCore.Loader.Abstractions.Extensions.Features;
using BlocksCore.Loader.Abstractions.Shell.Descriptor.Models;

namespace BlocksCore.Loader.Abstractions.Shell.Builders.Models
{
    /// <summary>
    /// Contains the information necessary to initialize an IoC container
    /// for a particular tenant. This model is created by the ICompositionStrategy
    /// and is passed into the IShellContainerFactory.
    /// </summary>
    public class ShellBlueprint
    {
        public ShellSettings Settings { get; set; }
        public ShellDescriptor Descriptor { get; set; }

        public IDictionary<Type, FeatureEntry> Dependencies { get; set; }
    }
}