using System;
using Microsoft.AspNetCore.Http;

namespace BlocksCore.Loader.Test.Stubs
{
    public class StubHttpContextAccessor : IHttpContextAccessor
    {
        public HttpContext HttpContext
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}