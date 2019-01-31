using System;
using System.Collections.Generic;
using System.Linq;
using BlocksCore.Mvc.Core.Route;
using BlocksCore.WebAPI.Controllers;
using BlocksCore.WebAPI.Controllers.Manager;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BlocksCore.WebAPI.Providers
{
    public class ModularApplicationApiModelProvider : IApplicationModelProvider
    {
        private readonly MvcControllerManager _mvcControllerManager;

        public ModularApplicationApiModelProvider(MvcControllerManager mvcControllerManager)
        {

            this._mvcControllerManager = mvcControllerManager;
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {

           

           
            var allApiServices = _mvcControllerManager.GetAll();
            foreach (var controllerModel in context.Result.Controllers)
            {
                
                var apiService = allApiServices.FirstOrDefault(s => s.ServiceInterfaceType == controllerModel.ControllerType);
                var controllerType = controllerModel.ControllerType;
                if (apiService != null)
                {
                    controllerModel.ControllerName =   controllerType.Name.EndsWith(ApiControllerConventional.Postfixes().FirstOrDefault()) ? 
                        controllerType.Name.Substring(0, controllerType.Name.Length - ApiControllerConventional.Postfixes().FirstOrDefault().Length) : controllerType.Name;
                    if (controllerModel.RouteValues.ContainsKey("area"))
                        controllerModel.RouteValues["area"] = apiService.ServicePrefix;
                    else
                    {
                        controllerModel.RouteValues.Add("area",apiService.ServicePrefix);
                    }
                    
                }

            }
        }

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
        }

        public int Order
        {
            get { return 1000 + 100; }
        }
    }
}