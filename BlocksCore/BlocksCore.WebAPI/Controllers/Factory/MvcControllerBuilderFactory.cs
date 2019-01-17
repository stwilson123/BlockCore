using System;
using System.Collections.Generic;
 
using Blocks.Framework.Web.Mvc.Controllers.Builder;
using Blocks.Framework.Web.Mvc.Controllers.Manager;
using BlocksCore.Application.Abstratctions.Controller.Builder;
using BlocksCore.Application.Core.Controller.Factory;
using BlocksCore.SyntacticAbstractions.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Blocks.Framework.Web.Mvc.Controllers.Factory
{
    public class MvcControllerBuilderFactory : DefaultControllerBuilderFactory
    {
        private readonly MvcControllerOption _mvcControllerOption;

        public MvcControllerBuilderFactory(IServiceProvider serviceProvider,MvcControllerOption mvcControllerOption) : base(serviceProvider)
        {
            Check.NotNull(mvcControllerOption, nameof(mvcControllerOption));
            _mvcControllerOption = mvcControllerOption;
        }

        public override IDefaultControllerBuilder<T> For<T>(string serviceName)
        {
            return new MvcControllerBuilder<T,MvcControllerActionBuilder<T>>(serviceName, _serviceProvider,
                _serviceProvider.GetService<MvcControllerManager>(),_mvcControllerOption.ApiControllerType);
        }

        public override IBatchDefaultControllerBuilder<T> ForAll<T>(string servicePrefix,IEnumerable<Type> serviceTypes)
        {
            return new BatchMvcControllerBuilder<T>(this, servicePrefix,serviceTypes);
        }
    }
}