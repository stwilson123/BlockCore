using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlocksCore.Test.NetFramework
{
   
    public class Collection
    {
        [Fact]
        public void EnumableIsReadOnly()
        {
            IEnumerable<TestItem> listString = new List<TestItem>() { new TestItem() { number = 0}, new TestItem() { number = 1} };

            //foreach (var item in listString)
            //{
            //    item = new TestItem() {  number = 3}; 
            //}
        }
    }


    class TestItem
    {
        public int number { get; set; }
    }
}
