using System;
using System.Collections.Generic;
using System.Globalization;
using BlocksCore.Abstractions.Shell;
using BlocksCore.Loader.Abstractions.Extensions.Features;
using BlocksCore.Loader.Abstractions.Modules;
using BlocksCore.Loader.Abstractions.Shell.Builders;
using BlocksCore.Loader.Abstractions.Shell.Builders.Models;
using BlocksCore.Loader.Extensions.Features;
using BlocksCore.Localization.Abstractions;
using BlocksCore.Localization.Abstractions.Source;
using BlocksCore.Localization.Core;
using BlocksCore.SyntacticAbstractions.NullObject;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Xunit;

namespace BlocksCore.Test.Localization
{
    public class ModuleStringLocalizerTests
    {
        

        private Mock<ILocalizationManager> _localizationManager;

        private Mock<ITenantShellManager> _tenantShellManager;

        private string sourceName = "ModuleCs";
        public ModuleStringLocalizerTests()
        {
            _localizationManager = new Mock<ILocalizationManager>();
            _tenantShellManager = new Mock<ITenantShellManager>();

            var featureInfo = new Mock<IFeatureInfo>();
            featureInfo.Setup(s => s.Id).Returns( sourceName);
       
            _tenantShellManager.Setup(t => t.GetCurrentTenantShellContext()).Returns(new ShellContext()
            {
                Blueprint = new ShellBlueprint(){ Dependencies = new Dictionary<Type, FeatureEntry>()
                {
                    { typeof(ModuleStringLocalizerTests),new NonCompiledFeatureEntry(featureInfo.Object
                    )}
       
                }}
  
            });
            
//            
//            
//            
//            
//            
//            
//            
//            
//            
//
//            

        }

        [Fact]
        public void Localizer_should_return_originalValue_IfKeyNotExists()
        {
            var cultrue = new CultureInfo("cs");
            SetupDictionary(cultrue,sourceName,new LocalizationDictionary(cultrue, sourceName,new Dictionary<string, string>()
                {  { "name","nameA"},{"name1","nameB"},{"name2","namec {0}"},{"name3","named {0} {1}"}}
            ));
            var localizer = new DefaultModularLocalizer<ModuleStringLocalizerTests>(cultrue, _localizationManager.Object,
                _tenantShellManager.Object   );

            Assert.Equal(localizer["name"], "nameA");
            Assert.Equal(localizer["name1"], "nameB");

            Assert.Equal(localizer["nameNotFound"], "nameNotFound");
            
            Assert.Equal(localizer["name2","test"], "namec test");
            Assert.Equal(localizer["name3","test"], "named {0} {1}");

        }
        
        private void SetupDictionary(CultureInfo culture, string sourceName,LocalizationDictionary localizationDictionary)
        {
            _localizationManager.Setup(s => s.GetDictionary(sourceName, culture))
                .Returns(localizationDictionary);
        }
    }
}