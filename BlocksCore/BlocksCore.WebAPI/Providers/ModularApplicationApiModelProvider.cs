using System.Linq;
using BlocksCore.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BlocksCore.WebAPI.Providers
{
    public class ModularApplicationApiModelProvider : IApplicationModelProvider
    {
        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            context.Result.Controllers.Where(c => c.ControllerType == typeof(ApiController));
        }

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            throw new System.NotImplementedException();
        }

        public int Order {
            get
            {
              return  1000 + 100;
            }
        }
    }
}