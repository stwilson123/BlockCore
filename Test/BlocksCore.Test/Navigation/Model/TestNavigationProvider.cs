using Blocks.Framework.Navigation;
using Blocks.Framework.Navigation.Provider;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Test.DependencyInjection.Model
{
    public class TestNavigationProvider : INavigationProvider
    {
        public IStringLocalizer T { get; set; }

        public void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu.AddItem(new NavigationItemDefinition("Test", new LocalizedString("", "")));
            context.Manager.MainMenu.AddBuilder((builder) =>
                builder.Name("Test1").DisplayName(new LocalizedString("", "")).Action("abc", "controller", "TestNavigationModule")
            );
            context.Manager.MainMenu.AddBuilder((builder) =>
                builder.Name("Test2").DisplayName(new LocalizedString("", "")).Action("abc", "controller", "TestNavigationModule")
                );

        }
    }
}
