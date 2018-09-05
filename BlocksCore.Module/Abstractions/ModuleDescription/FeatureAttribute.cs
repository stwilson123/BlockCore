using System;

namespace BlocksCore.Module.Abstractions.ModuleDescription
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class FeatureAttribute : Attribute
    {

        /// <summary>
        /// Folder name under virtual path base
        /// </summary>
        public string Id { get; internal set; }

  
     
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Priority { get; set; } = "0";

        public string[] Dependencies { get; set; } = Array.Empty<string>();

    }
}