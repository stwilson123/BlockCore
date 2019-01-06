using System;

namespace BlocksCore.Abstractions.Modules
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