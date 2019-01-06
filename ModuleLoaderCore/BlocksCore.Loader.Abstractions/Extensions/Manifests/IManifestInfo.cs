using System;
using System.Collections.Generic;
using BlocksCore.Loader.Abstractions.Modules.Manifest;

namespace BlocksCore.Loader.Abstractions.Extensions.Manifests
{
    public interface IManifestInfo
    {
        bool Exists { get; }
        string Name { get; }
        string Description { get; }
        string Type { get; }
        string Author { get; }
        string Website { get; }
        Version Version { get; }
        IEnumerable<string> Tags { get; }
        ModuleAttribute ModuleInfo { get; }
    }
}
