using BlocksCore.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Shell.Builders;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.WebAPI.Shell
{
    public class TenantShellManager : ITenantShellManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantShellManager(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public ShellContext GetCurrentTenantShellContext()
        {
            return _httpContextAccessor.HttpContext.Features.Get<ShellContext>();
        }
    }
}
