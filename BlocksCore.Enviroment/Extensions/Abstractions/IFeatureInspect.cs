using System.Collections.Generic;

namespace BlocksCore.Enviroment.Extensions.Abstractions
{
    public interface IFeatureInspect
    {
        void IsConformityInitalization(IEnumerable<IModuleInfo> moduleInfos);
    }
}