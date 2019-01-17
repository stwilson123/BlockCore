using System;
using System.Collections;
using System.Collections.Generic;
using BlocksCore.Application.Abstratctions.Controller.Factory;
using BlocksCore.Application.Core.Controller.Builder;


namespace Blocks.Framework.Web.Mvc.Controllers.Builder
{
    public class BatchMvcControllerBuilder<T> : BatchDefaultControllerBuilder<T>
    {
        protected override string[] ControllerPostfixes
        {
            get { return new string[] {"Controller"}; }
        }

        public BatchMvcControllerBuilder(IDefaultControllerBuilderFactory controllerBuilderFactory, string servicePrefix,IEnumerable<Type> servicesTypes) 
            : base(  controllerBuilderFactory, servicePrefix,servicesTypes)
        {
        }
    }
}