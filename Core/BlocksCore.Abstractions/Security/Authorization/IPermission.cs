using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Security.Authorization
{
    public interface IPermission
    {
        string Name { get; }

        string Navigation { get; }

        string ResourceKey { get; }

        LocalizedString DisplayName { get; }


        string Type { get; }
    }
}
