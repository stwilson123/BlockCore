using System;
using System.Collections.Generic;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Extensions.Features;
using BlocksCore.Loader.Abstractions.Extensions.Manifests;

namespace BlocksCore.Loader.Extensions
{
    public class ExtensionInfo : IExtensionInfo
    {
        public ExtensionInfo(
            string subPath,
            IManifestInfo manifestInfo,
            Func<IManifestInfo, IExtensionInfo, IEnumerable<IFeatureInfo>> features) {

            SubPath = subPath;
            Manifest = manifestInfo;
            Features = features(manifestInfo, this);
        }

        public string Id => Manifest.ModuleInfo.Id;
        public string SubPath { get; }
        public IManifestInfo Manifest { get; }
        public IEnumerable<IFeatureInfo> Features { get; }
        public bool Exists => Manifest.Exists;
    }
}
