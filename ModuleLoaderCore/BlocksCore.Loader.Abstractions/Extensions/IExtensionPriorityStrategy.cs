using BlocksCore.Loader.Abstractions.Extensions.Features;

namespace BlocksCore.Loader.Abstractions.Extensions
{
    public interface IExtensionPriorityStrategy
    {
        int GetPriority(IFeatureInfo feature);
    }
}
