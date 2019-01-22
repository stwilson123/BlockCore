using System;
using Microsoft.AspNetCore.Authorization;
using OrchardCore.Infrastructure.Security.Permissions;

namespace BlocksCore.Loader.Infrastructure.Security
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(Permission permission)
        {
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            Permission = permission;
        }

        public Permission Permission { get; set; }
    }
}


