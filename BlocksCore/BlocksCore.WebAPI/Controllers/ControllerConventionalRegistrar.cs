using System;
using System.Linq;
using System.Reflection;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.DependencyInjection;
using BlocksCore.Application.Abstratctions;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.WebAPI.Controllers.Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using BlocksCore.SyntacticAbstractions.Types;
namespace BlocksCore.WebAPI.Controllers
{
    /// <summary>
    /// Registers all MVC Controllers derived from <see cref="Controller"/>.
    /// </summary>
    public class ApiControllerConventional
    {
        private readonly IExtensionManager _extensionManager;
        private readonly MvcControllerBuilderFactory _mvcControllerBuilderFactory;

        internal static string GetControllerSerivceName(string area,string controllerName)
        {
            return $@"ApiController/{area}/{controllerName}";
        }

        public  static  string[] Postfixes()
        {
            return new[] {"Controller"};
        }

        internal ApiControllerConventional(IExtensionManager extensionManager,MvcControllerBuilderFactory mvcControllerBuilderFactory)
        {
            _extensionManager = extensionManager;
            _mvcControllerBuilderFactory = mvcControllerBuilderFactory;
        }

  
        internal void RegisterController()
        {

            var features = _extensionManager.LoadFeaturesAsync().Result;
            foreach (var feature in features)
            {
                _mvcControllerBuilderFactory.ForAll<IAppService>(feature.FeatureInfo.Id,
                    feature.ExportedTypes.Where(IsController)).Build();
            }
          
        }
        
        protected bool IsController(Type typeInfo)
        {
            if (!typeInfo.IsClass)
            {
                return false;
            }

            if (typeInfo.IsAbstract)
            {
                return false;
            }

            // We only consider public top-level classes as controllers. IsPublic returns false for nested
            // classes, regardless of visibility modifiers
            if (!typeInfo.IsPublic)
            {
                return false;
            }

            if (typeInfo.ContainsGenericParameters)
            {
                return false;
            }

            if (typeInfo.IsDefined(typeof(NonControllerAttribute)))
            {
                return false;
            }

            if (!typeInfo.Name.EndsWith(others:Postfixes() ,(name, fixes) => fixes.All(f => f) ) &&
                !typeInfo.IsDefined(typeof(ControllerAttribute)))
            {
                return false;
            }

            if (!typeof(IAppService).IsAssignableFrom(typeInfo))
                return false;
            return true;
        }
    }
}