using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BlocksCore.Localization.Abstractions;
using BlocksCore.Localization.Abstractions.Source;
using BlocksCore.Localization.Core;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlocksCore.Test.Localization
{
    public class LoaclizationManagerTests
    {
        private IMemoryCache _memoryCache;

        public LoaclizationManagerTests()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        [Fact]
        public void GetDictionary_Should_Return_Right_SouceType()
        {
           
            ILocalizationManager manager = new LocalizationManager(_memoryCache,new List<ILocalizationDictionaryProvider>()
            {
                new TestProviderCs(), new TestProviderEn()
                
            } );
            var csDic = manager.GetDictionary("ModuleCs", new CultureInfo("cs"));
            var enDic = manager.GetDictionary("ModuleEn", new CultureInfo("en"));

            Assert.Equal("cs", csDic.CultureInfo.Name);
            Assert.Equal("ModuleCs", csDic.SourceName);
            Assert.Equal("名字", csDic.Translations["name"]);
            
            Assert.Equal("en", enDic.CultureInfo.Name);
            Assert.Equal("ModuleEn", enDic.SourceName);
            Assert.Equal("Name", enDic.Translations["name"]);

        }
    }


    internal class TestProviderCs : ILocalizationDictionaryProvider
    {
        public SourceType[] Sources {
            get
            {
                return new SourceType[1]{ new SourceType(new CultureInfo("cs"),"ModuleCs" ) };
            }
        }
        public Task<ILocalizationDictionary> GetLocalizationDictionary()
        {
            ILocalizationDictionary dic = new LocalizationDictionary(Sources[0].CultureInfo, Sources[0].SourceName,
                new Dictionary<string, string>(){{"name","名字"}}
            );

            
            return Task.FromResult(dic);
        }
    }
    
    internal class TestProviderEn : ILocalizationDictionaryProvider
    {
        public SourceType[] Sources {
            get
            {
                return new SourceType[1]{ new SourceType(new CultureInfo("en"),"ModuleEn" ) };
            }
        }
        public Task<ILocalizationDictionary> GetLocalizationDictionary()
        {
            ILocalizationDictionary dic = new LocalizationDictionary(Sources[0].CultureInfo, Sources[0].SourceName,
                new Dictionary<string, string>(){{"name","Name"}}
                );
            
            return Task.FromResult(dic);
        }
    }
}