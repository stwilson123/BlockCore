using System.Threading.Tasks;
using BlocksCore.Loader.Abstractions.Shell.Descriptor.Models;

namespace BlocksCore.Loader.Abstractions.Shell
{
    /// <summary>
    /// Represent and event handler for shell descriptor.
    /// </summary>
    public interface IShellDescriptorManagerEventHandler
    {
        /// <summary>
        /// Triggered whenever a shell descriptor has changed.
        /// </summary>
        Task Changed(ShellDescriptor descriptor, string tenant);
    }
}
