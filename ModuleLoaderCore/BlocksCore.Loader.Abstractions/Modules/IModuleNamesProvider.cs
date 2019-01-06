using System.Collections.Generic;

namespace BlocksCore.Loader.Abstractions.Modules
{
    public interface IModuleNamesProvider
    {
        IEnumerable<string> GetModuleNames();
    }
}