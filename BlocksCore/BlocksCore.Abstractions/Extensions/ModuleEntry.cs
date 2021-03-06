﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BlocksCore.Abstractions.Extensions.Features;
using BlocksCore.Abstractions.Modules.ModuleDescription;

namespace BlocksCore.Abstractions.Extensions
{
    public class ModuleEntry
    {
//        public ModuleEntry(IModuleInfo moduleInfo, Assembly assembly)
//        {
//            ModuleInfo = moduleInfo;
//            Assembly = assembly;
//        }
        public IModuleInfo ModuleInfo { get; internal set; }
        
        public Assembly Assembly { get; internal set; }

        public IEnumerable<Type> ExportedTypes { get; internal set; }

        public IEnumerable<FeatureEntry> Features { get;internal set;  }

        public static ModuleEntry Create(string name,bool isApplication)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new ModuleEntry(){ ModuleInfo = new NullModuleInfo()};
            } 
            var moduleAssembly = Assembly.Load(name);
            var featureAttributes = moduleAssembly.GetCustomAttributes<FeatureAttribute>();
            var moduleAttribute = featureAttributes.FirstOrDefault(t => t is ModuleAttribute) as ModuleAttribute;
            featureAttributes = featureAttributes.Where(t => !(t is ModuleAttribute)).ToList();
            
            var moduleInfo = new ModuleInfo(moduleAttribute);
            moduleInfo.Features = moduleInfo.Features.Concat(featureAttributes.Select(f => new FeatureInfo(f))).ToList();
            

            var module = new ModuleEntry()
            {
                ModuleInfo = moduleInfo,
                Assembly = moduleAssembly,
                ExportedTypes = moduleAssembly.ExportedTypes
                //Maybe Combine with other Module 
                // Features = featureAttributes.Select(f => new FeatureEntry(){ ExportedTypes = })
            };
           // moduleAttribute.Features(featureAttributes);


            return module;
                
        }
        
    }
}