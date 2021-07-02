using System.Collections.Generic;
using System.Linq;
using ConsoleApp1;
using Xunit;

namespace TestProject1
{
    public class FolderSearchServiceOptimizedTests
    {
        [Fact]
        public void FindHangingNodes_ShouldFindTwoNodes()
        {
            var inputData = new List<Node>()
            {
                new Node() {Index = "2", Name = ""},
                new Node() {Index = "2.4", Name = ""},
                new Node() {Index = "2.7", Name = ""},
                new Node() {Index = "4.2", Name = ""},
                new Node() {Index = "4.3.37", Name = ""},
            };
            
            var testObject = new FolderSearchServiceOptimized();

            var result = testObject.FindHangingNodes(inputData);
            
            Assert.True(result != null && result.Count == 2, "should not be empty");
            Assert.True(result.Any((n) => n.Index == "4.2"), "should contains first node");
            Assert.True(result.Any((n) => n.Index == "4.3.37"),  "should contains second node");
        }
    }
}