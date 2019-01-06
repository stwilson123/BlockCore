using System.Collections.Generic;
using BlocksCore.ResourcesManagement.Abstractions;

namespace BlocksCore.ResourcesManagement
{
    public class ResourceManifestBuilder : IResourceManifestBuilder
    {
        public ResourceManifestBuilder()
        {
            ResourceManifests = new HashSet<Abstractions.ResourceManifest>();
        }

        internal HashSet<Abstractions.ResourceManifest> ResourceManifests { get; private set; }

        public Abstractions.ResourceManifest Add()
        {
            return Add(new Abstractions.ResourceManifest());
        }

        public Abstractions.ResourceManifest Add(Abstractions.ResourceManifest manifest)
        {
            ResourceManifests.Add(manifest);
            return manifest;
        }
    }
}
