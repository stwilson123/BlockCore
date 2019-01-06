using System.Collections.Generic;

namespace BlocksCore.Loader.Infrastructure.Commands
{
    public class CommandHandlerDescriptor
    {
        public IEnumerable<CommandDescriptor> Commands { get; set; }
    }
}