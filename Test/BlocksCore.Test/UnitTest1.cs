using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Xunit;

namespace BlocksCore.Test
{
    public class UnitTest1
    {
        [Fact]
        public void keyvaluePairEqual()
        {
            var KeyValuePairA = new KeyValuePair<string, Type>("KeyValuePair",typeof(UnitTest1));
            var KeyValuePairB = new KeyValuePair<string, Type>("KeyValuePair",typeof(UnitTest1));

            Assert.Equal(KeyValuePairA,KeyValuePairB);
            Assert.Equal(KeyValuePairA.GetHashCode(),KeyValuePairB.GetHashCode());

            
            
            var dicKeyValues = new ConcurrentDictionary <KeyValuePair<string, Type>,string>();
            
            
            var lazyKeyValuePairA =  dicKeyValues.GetOrAdd(KeyValuePairA,(o) => "KeyValuePairA");
            var lazyKeyValuePairB =  dicKeyValues.GetOrAdd(KeyValuePairA,(o) => "KeyValuePairB");
            Assert.Equal(lazyKeyValuePairA,lazyKeyValuePairB);
            
        }

        [Fact]
        public void NullEquals_shouldbe_ThrowException()
        {

            string a = null;
            Assert.Throws(typeof(NullReferenceException), () => { a.Equals(null); });
        }
    }
}