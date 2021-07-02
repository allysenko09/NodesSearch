using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var inputData = new List<InputNode>()
            {
                new InputNode() {Index = "2", Name = ""},
                new InputNode() {Index = "2.4", Name = ""},
                new InputNode() {Index = "2.7", Name = ""},
                new InputNode() {Index = "4.2", Name = ""},
                new InputNode() {Index = "4.3.37", Name = ""},
            };
            
            
            var testObject = new FolderSearchService();

            var result = testObject.FindHangingNodes(inputData);
            
            Assert.True(result != null && result.Count == 2, "should not be empty");
            Assert.True(result.Any((n) => n.Index == "4.2"), "should contains first node");
            Assert.True(result.Any((n) => n.Index == "4.3.37"),  "should contains second node");
            
        }
    }
}