using System.Collections.Generic;

namespace BlocksCore.Loader.Infrastructure.Commands.Parameters
{
    public interface ICommandParametersParser
    {
        CommandParameters Parse(IEnumerable<string> args);
    }
}