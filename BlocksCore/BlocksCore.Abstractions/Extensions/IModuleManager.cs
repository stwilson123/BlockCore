using System.Collections.Generic;
using System.Threading.Tasks;
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


        Task<IEnumerable<FeatureEntry>> LoadFeaturesAsync();
     //   Task<IEnumerable<FeatureEntry>> LoadFeaturesAsync(string[] featureIdsToLoad);

    }
}