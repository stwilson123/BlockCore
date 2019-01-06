using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlocksCore.Abstractions.Shell
{
    public interface IShellSettingsConfigurationProvider
    {
        void AddSource(IConfigurationBuilder builder);
        void SaveToSource(string name, IDictionary<string, string> configuration);

        int Order { get; }
    }
}
