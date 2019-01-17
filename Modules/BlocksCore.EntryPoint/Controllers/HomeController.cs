using Microsoft.AspNetCore.Mvc;

namespace BlocksCore.EntryPoint.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Backstage()
        {
            return View();
        }
    }
}