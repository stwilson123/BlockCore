using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace BlocksCore.Loader.Abstractions.Shell
{
    public interface IShellSettingsConfigurationProvider
    {
        void AddSource(IConfigurationBuilder builder);
        void SaveToSource(string name, IDictionary<string, string> configuration);

        int Order { get; }
    }
}
