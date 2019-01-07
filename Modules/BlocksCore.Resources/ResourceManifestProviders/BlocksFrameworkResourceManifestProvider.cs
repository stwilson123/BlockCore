using BlocksCore.ResourcesManagement.Abstractions;

namespace BlocksCore.Resources.ResourceManifestProviders
{
    public class BlocksFrameworkResourceManifestProvider : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();



          
        }
    }
}