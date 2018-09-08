using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Enviroment.Builder
{
    public class BlocksCoreBuilder
    {
        private IServiceCollection ApplicationServices { get; }
        public BlocksCoreBuilder(IServiceCollection services)
        {
            ApplicationServices = services;
        }
    }
}
