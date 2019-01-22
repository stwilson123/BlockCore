using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocksCore.Navigation.Abstractions;
using BlocksCore.Navigation.Abstractions.Filters;
using BlocksCore.Navigation.Abstractions.Manager;
using BlocksCore.Navigation.Abstractions.Provider;
using Microsoft.Extensions.Localization;
using NavigationProviderContext = BlocksCore.Navigation.Provider.NavigationProviderContext;

namespace BlocksCore.Navigation.Manager
{
    public class NavigationManager : INavigationManager
    {
        public IDictionary<string, INavigationDefinition> Menus { get; private set; }

        private readonly IEnumerable<INavigationProvider> _navigationProviders;
        private readonly IEnumerable<INavigationFilter> _navigationFilters;


        public INavigationDefinition MainMenu
        {
            get { return Menus["MainMenu"]; }
        }

 
//        private readonly INavigationConfiguration _configuration;

        public NavigationManager(IEnumerable<INavigationProvider> navigationProviders,IEnumerable<INavigationFilter> navigationFilters)
        {
            _navigationProviders = navigationProviders;
            _navigationFilters = navigationFilters;

            Menus = new Dictionary<string, INavigationDefinition>
            {
                {
                    "MainMenu", new NavigationDefinition("MainMenu",new LocalizedString("MainMenu","MainMenu"))
                }
            };
        }


        public void Initialize()
        {
            var context = new NavigationProviderContext(this);

            //should be register thought LocalizsableModeule
             
            foreach (var provider in _navigationProviders)
            {
                provider.SetNavigation(context);
            }

            Menus =    Filter(Menus).Result;

            //if(_iocResolver.IsRegistered<IDomainEventBus>())
            //{
            //    _iocResolver.Resolve<IDomainEventBus>().Trigger(new MenusInitEventData() {
            //        NavigationItems = Menus.SelectMany(t => t.Value.Items).ToArray()
            //    });
            //}
     

       
        }

        private async Task<IDictionary<string, INavigationDefinition>> Filter(
            IDictionary<string, INavigationDefinition> navItems)
        {
            var navigationFilters = _navigationFilters;
            var navResult = new Dictionary<string, INavigationDefinition>();
            foreach (var nav in navItems)
            {
                IEnumerable<INavigationDefinition> result = new List<INavigationDefinition>() {nav.Value};
                foreach (var filter in navigationFilters)
                {
                    result = await filter.Filter(result);
                }
                navResult.Add(nav.Key, result.FirstOrDefault());
            }

            return navResult;
        }

//        private MenuItemDefinition funTransfter(INavigationItemDefinition menuItem)
//        {
//            
//            var localizableString = (LocalizableString) (menuItem.DisplayName);
//            var menuDefinition = new MenuItemDefinition(
//                menuItem.Name,
//                new Abp.Localization.LocalizableString(localizableString.Name, localizableString.SourceName), null, RouteHelper.GetUrl(menuItem.RouteValues));
////            menuItem.Items?.ForEach(navigationItemDefinition =>
////            {
////                menuDefinition.AddItem(funTransfter(navigationItemDefinition));
////            });
//
//
//            return menuDefinition;
//        }

//        class RouteHelper
//        {
//            public static string GetUrl(IDictionary<string, object> routeValue)
//            {
//                if (routeValue == null || !routeValue.Any())
//                    return "";
//                var controllerServiceName = routeValue["area"]?.ToString() + "/" + routeValue["controller"]?.ToString()
//                                           + "/" + routeValue["action"]?.ToString();
//                return controllerServiceName;
//            }
//            public static string GetControllerPath(IDictionary<string, object> routeValue)
//            {
//                var controllerServiceName = routeValue["area"]?.ToString() + "/" + routeValue["controller"]?.ToString();
//                return controllerServiceName;
//            }
//        }

    }
}