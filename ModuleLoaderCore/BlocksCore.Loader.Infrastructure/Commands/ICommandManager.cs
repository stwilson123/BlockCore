using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlocksCore.Loader.Infrastructure.Commands
{
    public interface ICommandManager
    {
        Task ExecuteAsync(CommandParameters parameters);
        IEnumerable<CommandDescriptor> GetCommandDescriptors();
    }
}