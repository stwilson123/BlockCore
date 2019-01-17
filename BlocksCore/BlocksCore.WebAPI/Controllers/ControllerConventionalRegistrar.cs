using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.DependencyInjection;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Shell.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace Blocks.Framework.Web.Mvc.Controllers
{
    /// <summary>
    /// Registers all MVC Controllers derived from <see cref="Controller"/>.
    /// </summary>
    internal class ControllerConventional
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IExtensionManager _extensionManager;

        public static string GetControllerSerivceName(string area,string controllerName)
        {
            return $@"WebController/{area}/{controllerName}";
        }


        public ControllerConventional(IServiceCollection serviceCollection,IExtensionManager extensionManager)
        {
            _serviceCollection = serviceCollection;
            _extensionManager = extensionManager;
        }

  
        public void RegisterController()
        {

            var features = _extensionManager.LoadFeaturesAsync().Result;
               
      

            foreach (var feature in features)
            {
                foreach (var controllerType in feature.ExportedTypes.Where(isController))
                {
                    var area = AreaTemplate.GetAreaKey(new AreaOption() {AreaName =feature.FeatureInfo.Id, FunctionType = "Views"});
                    string serviceKey = GetControllerSerivceName(area, controllerType.Name);
                    _serviceCollection.AddTransient(serviceKey, controllerType);
                }
             
            }
          
        }
        
        Func<Type,bool> isController => (t) => 
            typeof(Controller).IsAssignableFrom(t) && !t.IsGenericTypeDefinition;
    }
}