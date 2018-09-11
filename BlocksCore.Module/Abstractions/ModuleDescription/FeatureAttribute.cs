using System;

namespace BlocksCore.Module.Abstractions.ModuleDescription
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public class FeatureAttribute : Attribute
    {

        public string Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Priority { get; set; } = "0";

        public string[] Dependencies { get; set; } = Array.Empty<string>();

    }
}