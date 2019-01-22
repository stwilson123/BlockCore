using OrchardCore.Infrastructure.Security.Permissions;

namespace OrchardCore.Infrastructure.Security
{
    public class StandardPermissions
    {
        public static readonly Permission SiteOwner = new Permission("SiteOwner", "Site Owners Permission");
    }
}
