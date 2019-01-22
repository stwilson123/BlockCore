using System.Threading.Tasks;

namespace OrchardCore.Infrastructure.Security
{
    public interface IRoleRemovedEventHandler
    {
        Task RoleRemovedAsync(string roleName);
    }
}