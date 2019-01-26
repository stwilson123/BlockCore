using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Mvc.Core.Route;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Mvc.Core
{
    public class ModularTenantRouteBuilder : IModularTenantRouteBuilder
    {
        private IRoutePublisher _routePublisher;
        // Register one top level TenantRoute per tenant. Each instance contains all the routes
        // for this tenant.
        public ModularTenantRouteBuilder(IRoutePublisher routePublisher)
        {
            _routePublisher = routePublisher;
        }

        public IRouteBuilder Build(IApplicationBuilder appBuilder)
        {
            var routeBuilder = new RouteBuilder(appBuilder)
            {
                DefaultHandler = appBuilder.ApplicationServices.GetRequiredService<MvcRouteHandler>()
            };

            return routeBuilder;
        }

        public void Configure(IRouteBuilder builder)
        {
            var inlineConstraintResolver = builder.ServiceProvider.GetService<IInlineConstraintResolver>();

           
         
            
            
            builder.Routes.Insert(0, AttributeRouting.CreateAttributeMegaRoute(builder.ServiceProvider));
            
            
            //Add all features route
            _routePublisher.Publish(builder);
            
            // The default route is added to each tenant as a template route, with a prefix
            builder.Routes.Add(new Microsoft.AspNetCore.Routing.Route(
                builder.DefaultHandler,
                "Default",
                "{area:exists}/{controller}/{action}/{id?}",
                null,
                null,
                null,
                inlineConstraintResolver)
            );
            
            
            
        }
    }
}