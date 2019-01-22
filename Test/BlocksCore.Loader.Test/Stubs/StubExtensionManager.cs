using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Extensions.Features;
using BlocksCore.Loader.Abstractions.Extensions.Loaders;

namespace BlocksCore.Loader.Test.Stubs
{
    public class StubExtensionManager : IExtensionManager
    {
        public IEnumerable<IFeatureInfo> GetDependentFeatures(string featureId)
        {
            throw new NotImplementedException();
        }

        public IExtensionInfo GetExtension(string extensionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IExtensionInfo> GetExtensions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFeatureInfo> GetFeatureDependencies(string featureId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFeatureInfo> GetFeatures()
        {
            return Enumerable.Empty<IFeatureInfo>();
        }

        public IEnumerable<IFeatureInfo> GetFeatures(string[] featureIdsToLoad)
        {
            throw new NotImplementedException();
        }

        public Task<ExtensionEntry> LoadExtensionAsync(IExtensionInfo extensionInfo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FeatureEntry>> LoadFeaturesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FeatureEntry>> LoadFeaturesAsync(string[] featureIdsToLoad)
        {
            throw new NotImplementedException();
        }
    }
}