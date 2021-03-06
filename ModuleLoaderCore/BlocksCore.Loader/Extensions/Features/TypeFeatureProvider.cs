﻿using System;
using System.Collections.Concurrent;
using BlocksCore.Loader.Abstractions.Extensions.Features;

namespace BlocksCore.Loader.Extensions.Features
{
    public class TypeFeatureProvider : ITypeFeatureProvider
    {
        private readonly ConcurrentDictionary<Type, IFeatureInfo> _features 
            = new ConcurrentDictionary<Type, IFeatureInfo>();

        public IFeatureInfo GetFeatureForDependency(Type dependency)
        {
            IFeatureInfo feature = null;

            if(_features.TryGetValue(dependency, out feature))
            {
                return feature;
            }

            return feature;
            // if not found feature,it will be null.

            // throw new InvalidOperationException($"Could not resolve feature for type {dependency.Name}");
        }

        public void TryAdd(Type type, IFeatureInfo feature)
        {
            _features.TryAdd(type, feature);
        }
    }
}