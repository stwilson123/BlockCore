using System;

namespace BlocksCore.Module.Abstractions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FeatureAttribute : Attribute
    {
        public string FeatureName { get; }

        public FeatureAttribute(string featureName)
        {
            FeatureName = featureName;
        }
    }
}