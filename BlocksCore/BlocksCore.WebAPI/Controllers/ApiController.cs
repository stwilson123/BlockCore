using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlocksCore.WebAPI.Controllers
{
    public class ApiController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new JsonResult("123");
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ;
        }
    }
}