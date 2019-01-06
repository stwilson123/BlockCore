using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Extensions.Features;

namespace BlocksCore.Loader.Extensions
{
    public class ExtensionPriorityStrategy : IExtensionPriorityStrategy
    {
        public int GetPriority(IFeatureInfo feature)
        {
            return feature.Priority;
        }
    }
}