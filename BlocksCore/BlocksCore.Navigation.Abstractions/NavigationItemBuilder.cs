﻿using System.Linq;
using BlocksCore.Abstractions.Security.Authorization;
using BlocksCore.SyntacticAbstractions.Types;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;

namespace BlocksCore.Navigation.Abstractions
{
    public class NavigationItemBuilder
    {
       

        protected NavigationItemDefinition _item;


        public NavigationItemBuilder()
        {
            _item = new NavigationItemDefinition();
        }

        public NavigationItemBuilder Name(string name)
        {
            _item.Name = name;
            return this;
        }


        public NavigationItemBuilder DisplayName(LocalizedString displayName)
        {
            _item.DisplayName = displayName;

            return this;
        }


        public NavigationItemDefinition Build()
        {
            //     _item.Items = base.Build();
            Check.NotNullOrEmpty(_item.Name, "The name of navigation item can't be null or empty ");
            Check.NotNull(_item.DisplayName, "The displayName of navigation item can't be null ");
            Check.NotNull(_item.RouteValues, "The RouteValues of navigation item can't be null ");
           

            return _item;
        }

        NavigationItemBuilder Action(RouteValueDictionary values)
        {
            return values != null
                ? Action(values["action"] as string, values["controller"] as string, values)
                : Action(null, null, new RouteValueDictionary());
        }

        NavigationItemBuilder Action(string actionName)
        {
            return Action(actionName, null, new RouteValueDictionary());
        }

        NavigationItemBuilder Action(string actionName, string controllerName)
        {
            return Action(actionName, controllerName, new RouteValueDictionary());
        }

        NavigationItemBuilder Action(string actionName, string controllerName, object values)
        {
            return Action(actionName, controllerName, new RouteValueDictionary(values));
        }

        public NavigationItemBuilder Action(string actionName, string controllerName, string areaName)
        {
            return Action(actionName, controllerName, new RouteValueDictionary(new {area = areaName}));
        }

        NavigationItemBuilder Action(string actionName, string controllerName, RouteValueDictionary values)
        {
            _item.RouteValues = new RouteValueDictionary(values);
            if (!string.IsNullOrEmpty(actionName))
                _item.RouteValues["action"] = actionName;
            if (!string.IsNullOrEmpty(controllerName))
                _item.RouteValues["controller"] = controllerName;
            return this;
        }

        public NavigationItemBuilder HasPermissions(params string[] permissionName)
        {
            var url = RouteHelper.GetUrl(_item.RouteValues);

            
            _item.HasPermissions = permissionName?.Select(p => Permission.Create(p,
                url, "Navigation", string.IsNullOrEmpty(url) ? null : url + "/" + p,
               new LocalizedString(_item.DisplayName.Name, p) )).ToArray();
            return this;
        }


        public NavigationItemBuilder Visible(bool IsVisible)
        {
            _item.IsVisible = IsVisible;

            return this;
        }
    }

}