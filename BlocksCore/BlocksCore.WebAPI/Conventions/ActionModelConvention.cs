using System.Linq;
using BlocksCore.WebAPI.Controllers;
using BlocksCore.WebAPI.Controllers.Manager;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BlocksCore.WebAPI
{
    internal class ActionModelConvention : IActionModelConvention
    {
        private MvcControllerManager _mvcControllerManager;
        public ActionModelConvention(MvcControllerManager mvcControllerManager)
        {
            _mvcControllerManager = mvcControllerManager;
            
        }
        public void Apply(ActionModel action)
        {
            var controllerInfo = _mvcControllerManager.GetAll()
                
                .FirstOrDefault(c => c.ServiceInterfaceType == action.Controller.ControllerType);
            if (controllerInfo == null )
                return;

            if (controllerInfo.Actions.TryGetValue(action.ActionName, out MvcControllerActionInfo actionInfo))
            {
                var controllerAttrs = actionInfo.Method.GetCustomAttributes(false);
               
                if (controllerAttrs.Any())
                {
                    action.Selectors.Clear();
                    ConventionHelper.AddRange(action.Selectors, ConventionHelper.CreateSelectors(controllerAttrs));
                }
            }
           
           // throw new System.NotImplementedException();
        }
    }
}