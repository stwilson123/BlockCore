using BlocksCore.ResourcesManagement.Abstractions;

namespace BlocksCore.Resources.ResourceManifestProviders
{
    public class BlocksFrameworkResourceManifestProvider : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineScript("vue")
               // .SetUrl("/OrchardCore.Resources/Scripts/bootstrap.min.js", "/OrchardCore.Resources/Scripts/bootstrap.js")
                .SetCdn("https://unpkg.com/vue@2.5.22/dist/vue.min.js", "https://unpkg.com/vue@2.5.22/dist/vue.js")
                //.SetCdnIntegrity("sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy", "sha384-fyOlGC+soQAvVFysE2KxkXaVKf75M1Zyo6RG7thLEEwD7p6/Cso7G/iV9tPM0C/a")
                .SetVersion("2.5.22")
                ;

            manifest
                .DefineScript("vue-router")
                .SetDependencies("vue")
                // .SetUrl("/OrchardCore.Resources/Scripts/bootstrap.min.js", "/OrchardCore.Resources/Scripts/bootstrap.js")
                .SetCdn("https://unpkg.com/vue-router@3.0.2/dist/vue-router.js",
                    "https://unpkg.com/vue-router@3.0.2/dist/vue-router.min.js")
                //.SetCdnIntegrity("sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy", "sha384-fyOlGC+soQAvVFysE2KxkXaVKf75M1Zyo6RG7thLEEwD7p6/Cso7G/iV9tPM0C/a")
                .SetVersion("3.0.2");
                ;
            manifest
                .DefineScript("require")
                // .SetUrl("/OrchardCore.Resources/Scripts/bootstrap.min.js", "/OrchardCore.Resources/Scripts/bootstrap.js")
                .SetCdn("https://cdn.bootcss.com/require.js/2.3.6/require.js",
                    "https://cdn.bootcss.com/require.js/2.3.6/require.min.js")
                //.SetCdnIntegrity("sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy", "sha384-fyOlGC+soQAvVFysE2KxkXaVKf75M1Zyo6RG7thLEEwD7p6/Cso7G/iV9tPM0C/a")
                .SetVersion("2.3.6");
            ;


          
        }
    }
}