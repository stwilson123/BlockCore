using Microsoft.Extensions.FileProviders;
using OrchardCore.Infrastructure.Scripting;

namespace BlocksCore.Loader.Infrastructure.Scripting.Files
{
    public class FilesScriptScope : IScriptingScope
    {
        public FilesScriptScope(IFileProvider fileProvider, string basePath)
        {
            FileProvider = fileProvider;
            BasePath = basePath;
        }

        public IFileProvider FileProvider { get; }
        public string BasePath { get; }
    }
}
