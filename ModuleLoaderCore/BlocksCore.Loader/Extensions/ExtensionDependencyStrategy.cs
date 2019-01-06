using System.Linq;
using BlocksCore.Loader.Abstractions.Extensions;
using BlocksCore.Loader.Abstractions.Extensions.Features;

namespace BlocksCore.Loader.Extensions
{
    public class ExtensionDependencyStrategy : IExtensionDependencyStrategy
    {
        public bool HasDependency(IFeatureInfo observer, IFeatureInfo subject)
        {
            return observer.Dependencies.Contains(subject.Id);
        }
    }
}