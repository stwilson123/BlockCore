using System.Collections.Generic;

namespace OrchardCore.Infrastructure.Security
{
    public class Role: IRole
    {
        public string RoleName { get; set; }
        public string NormalizedRoleName { get; set; }
        public List<RoleClaim> RoleClaims { get; } = new List<RoleClaim>();
    }
}
