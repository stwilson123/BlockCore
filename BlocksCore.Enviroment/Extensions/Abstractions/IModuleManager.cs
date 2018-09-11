using System.Collections.Generic;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;

namespace BlocksCore.Enviroment.Extensions.Abstractions
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