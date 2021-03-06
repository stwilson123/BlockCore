﻿using System;

namespace BlocksCore.Abstractions.Modules.ModuleDescription
{
    /// <summary>
    /// Define a Module Which is nesscessed.  
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class ModuleAttribute : FeatureAttribute
    {
        /// <summary>
        /// The Module type.
        /// </summary>
        public string ModuleType { get; set; } = "Module";
        
        public string Author { get; set; }
        
        public string Tags { get; set; }
        
        public string Version { get; set; } = "0.0";
        
       // public IEnumerable<FeatureAttribute> Features { get; } = Enumerable.Empty<FeatureAttribute>();
    }
}