using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Loader.Abstractions.Modules.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BlocksCore.Admin.Controllers
{
    public class AdminController : Controller
    {
      
        public AdminController()
        {
            
        }        
        public ActionResult Index()
        {
            
            return PartialView();
        }
    }
}