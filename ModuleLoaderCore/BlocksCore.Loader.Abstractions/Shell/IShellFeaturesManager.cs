using System.Collections.Generic;
using System.Threading.Tasks;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Extensions.Features;

namespace BlocksCore.Loader.Abstractions.Shell
{
    public interface IShellFeaturesManager
    {
        Task<IEnumerable<IFeatureInfo>> GetEnabledFeaturesAsync();
        Task<IEnumerable<IFeatureInfo>> GetDisabledFeaturesAsync();
        Task<(IEnumerable<IFeatureInfo>, IEnumerable<IFeatureInfo>)> UpdateFeaturesAsync(
            IEnumerable<IFeatureInfo> featuresToDisable, IEnumerable<IFeatureInfo> featuresToEnable, bool force);
        Task<IEnumerable<IExtensionInfo>> GetEnabledExtensionsAsync();
    }
}
