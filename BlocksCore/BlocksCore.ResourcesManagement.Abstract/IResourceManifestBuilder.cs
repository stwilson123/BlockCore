namespace BlocksCore.ResourcesManagement.Abstractions
{
    public interface IResourceManifestBuilder
    {
        ResourceManifest Add();

        ResourceManifest Add(ResourceManifest manifest);
    }
}
