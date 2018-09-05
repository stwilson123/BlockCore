using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;
using BlocksCore.Enviroment.Extensions.Features;

namespace BlocksCore.Enviroment.Extensions
{
    public class ModuleManager : IModuleManager
    {
        private IApplicationEnviroment _applicationEnviroment;

        private IDictionary<string, ModuleEntry> _modules ;

        private IDictionary<string, FeatureEntry> _features;

        
        private static object initializationLock = new object();
        private bool _isInitialized = false;
        public ModuleManager(IApplicationEnviroment applicationEnviroment)
        {
            _applicationEnviroment = applicationEnviroment;
       
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

               //  Parallel.ForEach()
                
                
                
                _isInitialized = true;
            }
        }
    }
}