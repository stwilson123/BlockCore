using System.Collections.Generic;
using BlocksCore.Abstractions.Extensions.Features;

namespace BlocksCore.Abstractions.Extensions
{
    public interface IModuleManager
    {
        IModuleInfo GetModuleInfo(string Id);
        
        IEnumerable<IModuleInfo> GetModuleInfos();

        IEnumerable<IFeatureInfo> GetFeatures();

        IFeatureInfo GetFeature(string featureId);


        IEnumerable<IFeatureInfo> GetDependentFeatures(string featureId);

    }
}