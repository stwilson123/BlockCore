namespace BlocksCore.ResourcesManagement.Abstractions
{
    public interface IResourceManifestProvider
    {
        void BuildManifests(IResourceManifestBuilder builder);
    }
}
