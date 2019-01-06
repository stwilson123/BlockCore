using System.Collections.Generic;
using System.Threading.Tasks;
using BlocksCore.Loader.Abstractions.Extensions.Features;
using BlocksCore.Loader.Abstractions.Shell.Descriptor.Models;

namespace BlocksCore.Loader.Abstractions.Shell
{
    public delegate void FeatureDependencyNotificationHandler(string messageFormat, IFeatureInfo feature, IEnumerable<IFeatureInfo> features);

    public interface IShellDescriptorFeaturesManager
    {
        Task<(IEnumerable<IFeatureInfo>, IEnumerable<IFeatureInfo>)> UpdateFeaturesAsync(ShellDescriptor shellDescriptor,
            IEnumerable<IFeatureInfo> featuresToDisable, IEnumerable<IFeatureInfo> featuresToEnable, bool force);
    }
}
