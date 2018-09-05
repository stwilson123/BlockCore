using System.Collections.Generic;
using System.Linq;
using BlocksCore.Enviroment.Extensions.Abstractions;
using BlocksCore.Enviroment.Extensions.Abstractions.Features;

namespace BlocksCore.Enviroment.Extensions
{
    public class ModuleManager : IModuleManager
    {
        public IModuleInfo GetModuleInfo(string Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IFeatureInfo> GetFeatures()
        {
            throw new System.NotImplementedException();
        }
    }
}