using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BlocksCore.Infrastructure.Security.Permissions;

namespace BlocksCore.Loader.Infrastructure.Security
{
    public static class AuthorizationServiceExtensions
    {
        public static Task<bool> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, Permission permission)
        {
            return AuthorizeAsync(service, user, permission, null);
        }

        public static async Task<bool> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, Permission permission, object resource)
        {
            if (user == null)
            {
                return false;
            }

            return (await service.AuthorizeAsync(user, resource, new PermissionRequirement(permission))).Succeeded;
        }
    }
}
