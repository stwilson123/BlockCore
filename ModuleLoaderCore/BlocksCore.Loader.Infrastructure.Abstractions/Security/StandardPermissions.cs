using BlocksCore.Infrastructure.Security.Permissions;

namespace BlocksCore.Infrastructure.Security
{
    public class StandardPermissions
    {
        public static readonly Permission SiteOwner = new Permission("SiteOwner", "Site Owners Permission");
    }
}
