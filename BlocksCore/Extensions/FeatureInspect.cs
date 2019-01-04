using System.Collections.Generic;
using System.Linq;
using BlocksCore.Abstractions.Extensions;
using BlocksCore.SyntacticAbstractions.Types;

namespace BlocksCore.Extensions
{
    public class FeatureInspect : IFeatureInspect
    {
        public void IsConformityInitalization(IEnumerable<IModuleInfo> moduleInfos)
        {
            foreach (var module in moduleInfos)
            {
                if (module.Name.IsNullOrEmpty())
                    throw new BlocksEnviromentException("Module name must define in ModuleAttribute.");
                
                if (module.Features.IsNullOrEmpty())
                    throw new BlocksEnviromentException($"Module '{module.Name}' must define a FeatureAttribute at lastest.");
                
                if (module.Features.Any(f => f.Id.IsNullOrEmpty()))
                    throw new BlocksEnviromentException($"All features of Module '{module.Name}' must define a property of Id.");
            }
            
        }
    }
}