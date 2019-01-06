using System.Collections.Generic;
using BlocksCore.Loader.Abstractions.Extensions.Manifests;

namespace BlocksCore.Loader.Abstractions.Extensions.Features
{
    public interface IFeaturesProvider
    {
        IEnumerable<IFeatureInfo> GetFeatures(
            IExtensionInfo extensionInfo,
            IManifestInfo manifestInfo);
    }
}
