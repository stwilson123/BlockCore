using System;
using System.Collections.Generic;
using BlocksCore.Abstractions.Environment.Shell.Descriptor.Models;
using BlocksCore.Abstractions.Extensions.Features;

namespace BlocksCore.Abstractions.Shell.Builders.Models
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