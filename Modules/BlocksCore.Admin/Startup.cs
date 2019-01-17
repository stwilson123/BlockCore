using System;
using BlocksCore.Loader.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace BlocksCore.Admin
{
    public class Startup : StartupBase
    {

   
        
        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {

            
            routes.MapAreaRoute(name: "Admin", areaName: "BlocksCore.EntryPoint",
                template:"Admin",
                defaults: new {controller = "Home", action = "Backstage"}
                
            );
           
        }
    }
}