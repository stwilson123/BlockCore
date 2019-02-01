using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Loader.Abstractions.Modules.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Admin.Controllers
{
    
    public class AdminController : Controller
    {
        private IStringLocalizer T;
        
        public AdminController(IStringLocalizer<AdminController> t)
        {
            this.T = t;
        }    
        
        [HttpPost]
        public ActionResult Index()
        {
            
            return PartialView();
        }
        
        public ActionResult Index2()
        {
            
            return PartialView();
        }
    }
}