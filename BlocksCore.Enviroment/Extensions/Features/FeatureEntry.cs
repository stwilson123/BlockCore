using System;
using System.Collections.Generic;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;

namespace BlocksCore.Enviroment.Extensions.Features
{
    public class FeatureEntry
    {
        public FeatureEntry(IFeatureInfo featureInfo, IEnumerable<Type> exportedTypes)
        {
            FeatureInfo = featureInfo;
            ExportedTypes = exportedTypes;
        }

        public IFeatureInfo FeatureInfo { get; internal set; }
        
        public IEnumerable<Type> ExportedTypes { get; internal set; }
    }
}