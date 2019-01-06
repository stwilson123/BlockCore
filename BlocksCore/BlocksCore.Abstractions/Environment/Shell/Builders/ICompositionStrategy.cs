using System.Threading.Tasks;
using BlocksCore.Abstractions.Environment.Shell.Descriptor.Models;
using BlocksCore.Abstractions.Shell.Builders.Models;

namespace BlocksCore.Abstractions.Shell.Builders
{
    /// <summary>
    /// Service at the host level to transform the cachable descriptor into the loadable blueprint.
    /// </summary>
    public interface ICompositionStrategy
    {
        /// <summary>
        /// Using information from the IExtensionManager, transforms and populates all of the
        /// blueprint model the shell builders will need to correctly initialize a tenant IoC container.
        /// </summary>
        Task<ShellBlueprint> ComposeAsync(ShellSettings settings, ShellDescriptor descriptor);
    }
}