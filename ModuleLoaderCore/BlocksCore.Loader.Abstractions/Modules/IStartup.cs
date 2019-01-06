﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace BlocksCore.Loader.Abstractions.Modules
{
    /// <summary>
    /// An implementation of this interface is used to initialize the services and HTTP request
    /// pipeline of a module.
    /// </summary>
    public interface IStartup
    {
        /// <summary>
        /// Get the value to use to order startups. The default is 0.
        /// </summary>
        int Order { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="routes"></param>
        /// <param name="serviceProvider"></param>
        void Configure(IApplicationBuilder builder, IRouteBuilder routes, IServiceProvider serviceProvider);
    }
}
