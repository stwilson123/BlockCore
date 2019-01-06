using BlocksCore.Loader.Abstractions.Extensions.Features;

namespace BlocksCore.Loader.Abstractions.Extensions
{
    public interface IExtensionDependencyStrategy
    {
        bool HasDependency(IFeatureInfo observer, IFeatureInfo subject);
    }
}
