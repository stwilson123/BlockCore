using System.ComponentModel.DataAnnotations;
using BlocksCore.Application.Abstratctions;
using BlocksCore.Application.Abstratctions.Controller.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace BlocksCore.Admin.Services
{
    
    public class AdminService : IAppService
    {
        [HttpPost]
        [BlocksActionName("TestOutPut")]
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