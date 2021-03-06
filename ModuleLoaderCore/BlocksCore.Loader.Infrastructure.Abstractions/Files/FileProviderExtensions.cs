using Microsoft.Extensions.FileProviders;

namespace OrchardCore.Infrastructure.Files
{
    public static class FileProviderExtensions
    {
        /// <summary>
        /// Locate a file at the give relative paths
        /// </summary>
        public static IFileInfo GetRelativeFileInfo(this IFileProvider provider, string path, string other = null)
        {
            return provider.GetFileInfo(PathExtensions.ResolvePath(PathExtensions.Combine(path, other)));
        }
    }
}
