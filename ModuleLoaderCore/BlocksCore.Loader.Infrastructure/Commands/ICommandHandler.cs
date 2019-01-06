using System.Threading.Tasks;

namespace BlocksCore.Loader.Infrastructure.Commands
{
    public interface ICommandHandler
    {
        Task ExecuteAsync(CommandContext context);
    }
}