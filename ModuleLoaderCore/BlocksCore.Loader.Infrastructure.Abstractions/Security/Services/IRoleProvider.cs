using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OrchardCore.Infrastructure.Security.Services
{
    public interface IRoleProvider
    {
        Task<IEnumerable<string>> GetRoleNamesAsync();
        Task<IEnumerable<Claim>> GetRoleClaimsAsync(string role, CancellationToken cancellationToken = default);
    }

}
