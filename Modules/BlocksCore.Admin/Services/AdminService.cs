using BlocksCore.Application.Abstratctions;
using Microsoft.AspNetCore.Mvc;

namespace BlocksCore.Admin.Services
{
    public class AdminService : IAppService
    {

        public a TestOutPut(string a )
        {
            return new a() { MyProperty = "1" };
        }
    }

    public class a
    {
        public string MyProperty { get; set; }
    }
}