using System;
using System.Linq;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.DependencyInjection;
using BlocksCore.Loader.Abstractions.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.WebAPI.Controllers
{
    /// <summary>
    /// Registers all MVC Controllers derived from <see cref="Controller"/>.
    /// </summary>
    public class ControllerConventional
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IExtensionManager _extensionManager;

        internal static string GetControllerSerivceName(string area,string controllerName)
        {
            return $@"WebController/{area}/{controllerName}";
        }

        public  static  string[] Postfixes()
        {
            return new[] {"Controller"};
        }

        internal ControllerConventional(IServiceCollection serviceCollection,IExtensionManager extensionManager)
        {
            _serviceCollection = serviceCollection;
            _extensionManager = extensionManager;
        }

  
        internal void RegisterController()
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