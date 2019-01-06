using System.Threading.Tasks;

namespace BlocksCore.Infrastructure.Security
{
    public interface IRoleRemovedEventHandler
    {
        Task RoleRemovedAsync(string roleName);
    }
}