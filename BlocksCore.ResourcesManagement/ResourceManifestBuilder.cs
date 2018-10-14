using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.ResourcesManagement
{
    public class ResourceManifestBuilder
    {
        public ResourceManifestBuilder()
        {
            ResourceManifests = new HashSet<IResourceManifest>();
        }



        internal HashSet<IResourceManifest> ResourceManifests { get; private set; }

        public ResourceManifest Add()
        {
            var manifest = new ResourceManifest { Feature = Feature };
            ResourceManifests.Add(manifest);
            return manifest;
        }

        public void Add(IResourceManifest manifest)
        {
            ResourceManifests.Add(manifest);
        }

    }
}
