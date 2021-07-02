using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class FolderSearchServiceOptimized
    {
        //O(n) в лучшем случае, - O(n2) в худшем, зависит от коллизий в Dictionary 
        public List<Node> FindHangingNodes(List<Node> inputNodes)
        {
            //O(n)
            var dict = inputNodes.ToDictionary(n => n.Index);

            var hangingNodes = new List<Node>();

            //O(n)
            foreach (var node in inputNodes)
            {
                //O(1)-O(n)
                if (!IsTopLevelAccessible(node, dict))
                {
                    hangingNodes.Add(node);
                }
            }
            
            return hangingNodes;
        }

        private bool IsTopLevelAccessible(Node node, Dictionary<string, Node> nodes)
        {
            while (node != null)
            {
                if (node.IsTopLevelNode)
                {
                    return true;
                }
                else
                {
                    //O(1)-O(n)
                    nodes.TryGetValue(node.ParentIndex, out node);
                }
            }

            return false;
        }
    }
}