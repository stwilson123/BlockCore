using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Security.Authorization
{
    public class Permission : IPermission
    {
        public static string PermissionTemplate = "{0}/{1}";
        public string Name { get; internal set; }

        public string Navigation { get; internal set; }

        public LocalizedString DisplayName { get; internal set; }

        // internal IPermissionDependency PermissionDependency { get; set; }

        public string Type { get; internal set; }

        public string ResourceKey { get; internal set; }

        public static Permission Create(string name, string navigation, string type,
            string resourceKey,
            LocalizedString displayName//, IPermissionDependency permissionDependency = null
            )
        {
            Permission p = new Permission
            {
                Name = name,
                Navigation = navigation,
                Type = type,
                ResourceKey = resourceKey,
                DisplayName = displayName,
            };
            //var pDependency = permissionDependency != null ? permissionDependency :
            //   new DefaultPermissionDependency(p);
            //p.PermissionDependency = pDependency;

            return p;
        }
    }
}
