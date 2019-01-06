using System;
using BlocksCore.ResourcesManagement.Abstractions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BlocksCore.ResourcesManagement.TagHelpers
{

    [HtmlTargetElement("style", Attributes = NameAttributeName)]
    [HtmlTargetElement("style", Attributes = SrcAttributeName)]
    public class StyleTagHelper : TagHelper
    {
        private const string NameAttributeName = "asp-name";
        private const string SrcAttributeName = "asp-src";

        [HtmlAttributeName(NameAttributeName)]
        public string Name { get; set; }

        [HtmlAttributeName(SrcAttributeName)]
        public string Source { get; set; }

        public string CdnSrc { get; set; }
        public string DebugSrc { get; set; }
        public string DebugCdnSrc { get; set; }

        public bool? UseCdn { get; set; }
        public string Condition { get; set; }
        public string Culture { get; set; }
        public bool? Debug { get; set; }
        public string Dependencies { get; set; }
        public string Version { get; set; }

        public ResourceLocation At { get; set; }

        private readonly IResourceManager _resourceManager;

        public StyleTagHelper(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Source))
            {
                // Include custom script
                var setting = _resourceManager.Include("stylesheet", Source, DebugSrc);

                if (At != ResourceLocation.Unspecified)
                {
                    setting.AtLocation(At);
                }
                else
                {
                    setting.AtLocation(ResourceLocation.Head);
                }

                if (!String.IsNullOrEmpty(Condition))
                {
                    setting.UseCondition(Condition);
                }

                if (Debug != null)
                {
                    setting.UseDebugMode(Debug.Value);
                }

                if (!String.IsNullOrEmpty(Culture))
                {
                    setting.UseCulture(Culture);
                }
            }
            else if (!String.IsNullOrEmpty(Name) && String.IsNullOrEmpty(Source))
            {
                // Resource required

                var setting = _resourceManager.RegisterResource("stylesheet", Name);

                if (At != ResourceLocation.Unspecified)
                {
                    setting.AtLocation(At);
                }
                else
                {
                    setting.AtLocation(ResourceLocation.Head);
                }

                if (UseCdn != null)
                {
                    setting.UseCdn(UseCdn.Value);
                }

                if (!String.IsNullOrEmpty(Condition))
                {
                    setting.UseCondition(Condition);
                }

                if (Debug != null)
                {
                    setting.UseDebugMode(Debug.Value);
                }

                if (!String.IsNullOrEmpty(Culture))
                {
                    setting.UseCulture(Culture);
                }

                if (!String.IsNullOrEmpty(Version))
                {
                    setting.UseVersion(Version);
                }
            }
            else if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Source))
            {
                // Inline declaration

                var definition = _resourceManager.InlineManifest.DefineStyle(Name);
                definition.SetUrl(Source, DebugSrc);

                if (!String.IsNullOrEmpty(Version))
                {
                    definition.SetVersion(Version);
                }

                if (!String.IsNullOrEmpty(CdnSrc))
                {
                    definition.SetCdn(CdnSrc, DebugCdnSrc);
                }

                if (!String.IsNullOrEmpty(Culture))
                {
                    definition.SetCultures(Culture.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }

                if (!String.IsNullOrEmpty(Dependencies))
                {
                    definition.SetDependencies(Dependencies.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }

                // Also include the style

                var setting = _resourceManager.RegisterResource("stylesheet", Name);

                if (At != ResourceLocation.Unspecified)
                {
                    setting.AtLocation(At);
                }
                else
                {
                    setting.AtLocation(ResourceLocation.Head);
                }

                if (UseCdn != null)
                {
                    setting.UseCdn(UseCdn.Value);
                }

                if (!String.IsNullOrEmpty(Condition))
                {
                    setting.UseCondition(Condition);
                }

                if (Debug != null)
                {
                    setting.UseDebugMode(Debug.Value);
                }

                if (!String.IsNullOrEmpty(Culture))
                {
                    setting.UseCulture(Culture);
                }
            }
            
            output.TagName = null;
        }
    }
}
