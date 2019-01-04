using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BlocksCore.Abstractions;
using BlocksCore.Abstractions.Extensions;
using BlocksCore.Abstractions.Extensions.Features;
using BlocksCore.Abstractions.Modules.ModuleDescription;
using BlocksCore.Extensions.Features;
using BlocksCore.SyntacticAbstractions.Collection;

namespace BlocksCore.Extensions
{
    public class ModuleManager : IModuleManager
    {
        private readonly IHostApplicationEnviroment _hostApplicationEnviroment;
        private readonly IFeatureInspect _featureInspect;

        private IDictionary<string, ModuleEntry> _modules ;

        private IDictionary<string, FeatureEntry> _features;

        private IEnumerable<IFeatureInfo> featureInfos => _features.Select(f => f.Value.FeatureInfo);
        private LazyConcurrentDictionary<string, IEnumerable<IFeatureInfo>> _dependentFeatures = new LazyConcurrentDictionary<string, IEnumerable<IFeatureInfo>>();

        private static object initializationLock = new object();
        private bool _isInitialized = false;
        public ModuleManager(IHostApplicationEnviroment hostApplicationEnviroment,IFeatureInspect featureInspect)
        {
            _hostApplicationEnviroment = hostApplicationEnviroment;
            _featureInspect = featureInspect;
            _modules = new ConcurrentDictionary<string, ModuleEntry>();
            _features = new ConcurrentDictionary<string, FeatureEntry>();
        }

        public IModuleInfo GetModuleInfo(string Id)
        {
            EnsureInitialized();
            ModuleEntry moduleEntry;
            if (_modules.TryGetValue(Id, out moduleEntry))
            {
                return moduleEntry.ModuleInfo;
            }
            
            return new NullModuleInfo();
        }

        public IEnumerable<IModuleInfo> GetModuleInfos()
        {
            EnsureInitialized();

            return _modules.Select(t => t.Value?.ModuleInfo);
        }

        public IEnumerable<IFeatureInfo> GetFeatures()
        {
            EnsureInitialized();
            return _features.Select(t => t.Value?.FeatureInfo);
        }

        private void EnsureInitialized()
        {
            if (_isInitialized)
                return;

            lock (initializationLock)
            {
                if (_isInitialized)
                    return;

               
                Parallel.ForEach(_hostApplicationEnviroment.ModuleNames,
                    new ParallelOptions() {MaxDegreeOfParallelism = 8}, ModulesLoad);
                
                _featureInspect.IsConformityInitalization(_modules.Select(m => m.Value.ModuleInfo).ToList());
                var typeFeatures = _modules.SelectMany(m =>
                {
                    var firstFeatureId = m.Value.ModuleInfo.Features?.FirstOrDefault()?.Id;
                    return m.Value.ExportedTypes.Where(IsComponentType).Select(e => new { featureName = GetSourceFeatureNameForType(e, m.Key), type = e });
                })
                .GroupBy(c => c.featureName).ToDictionary(g => g.Key, g => g.Select(t => t.type));
                
                _features = _modules.SelectMany(m => m.Value.ModuleInfo.Features).Distinct()
                    .ToDictionary(f => f.Id, f =>  
                        typeFeatures.TryGetValue(f.Id, out var types) ? new FeatureEntry(f, types) : new FeatureEntry(f, Enumerable.Empty<Type>())                      
                        );
                _isInitialized = true;
            }
        }

        private static bool IsComponentType(Type e)
        {
            return e.IsClass && !e.IsAbstract && e.IsPublic;
        }

        private void ModulesLoad(string name)
        {
            var module = ModuleEntry.Create(name, name == _hostApplicationEnviroment.ApplicationName);
            _modules.Add(name, module);
        }

        public IFeatureInfo GetFeature(string featureId)
        {
            EnsureInitialized();
            FeatureEntry featureEntry;
            if (_features.TryGetValue(featureId, out featureEntry))
            {
                return featureEntry.FeatureInfo;
            }

            return new NullFeatureInfo();
        }

        private IEnumerable<IFeatureInfo> GetFeatureDependencies(IFeatureInfo sourceFeatureInfo)
        {
            var denpendencies = new HashSet<IFeatureInfo>() { sourceFeatureInfo };
            var features = featureInfos;
            var stackExchange = new Stack<IFeatureInfo[]>();

            stackExchange.Push(findFeatureInfos(sourceFeatureInfo, features));

            while (stackExchange.Any())
            {
                var nexts = stackExchange.Pop();
                //Circle depend
                foreach (var denpendency in nexts.Where(n => !denpendencies.Contains(n)))
                {
                    denpendencies.Add(denpendency);
                    stackExchange.Push(findFeatureInfos(denpendency, features));
                }
            }

            return denpendencies;

        }

        private static IFeatureInfo[] findFeatureInfos(IFeatureInfo sourceFeatureInfo, IEnumerable<IFeatureInfo> features)
        {
            return features.Where(f => f.Dependencies.Any(d => string.Equals(d, sourceFeatureInfo.Id, StringComparison.Ordinal))).ToArray();
        }

        private static string GetSourceFeatureNameForType(Type type, string firstFeatureId)
        {
            var attribute = type.GetCustomAttributes<FeatureAttribute>(false).FirstOrDefault();

            return attribute?.Name ?? firstFeatureId;
        }

        public IEnumerable<IFeatureInfo> GetDependentFeatures(string featureId)
        {
            EnsureInitialized();

            return _dependentFeatures.GetOrAdd(featureId, fId =>
            {
                if (!_features.TryGetValue(fId, out var featureEntry))
                    return Enumerable.Empty<IFeatureInfo>();
               
                 return GetFeatureDependencies(featureEntry.FeatureInfo);
            });

        }
    }
}