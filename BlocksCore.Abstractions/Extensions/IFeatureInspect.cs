using System.Collections.Generic;

namespace BlocksCore.Abstractions.Extensions
{
    public interface IFeatureInspect
    {
        void IsConformityInitalization(IEnumerable<IModuleInfo> moduleInfos);
    }
}