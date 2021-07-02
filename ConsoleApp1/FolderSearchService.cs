using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class FolderSearchService
    {
        public List<Node> FindHangingNodes(List<InputNode> inputNodes)
        {
            var nodes = new List<Node>(inputNodes.Count);
            
            foreach (var inputNode in inputNodes)
            {
                nodes.Add(new Node() {Name = inputNode.Name, Index = inputNode.Index});
            }

            foreach (var node in nodes)
            {
                AddParent(node, nodes);
            }

            return FindHangingNodes(nodes);
        }

        private void AddParent(Node node, List<Node> nodes)
        {
            if (!node.IsTopLevelNode)
            {
                var parent = nodes.FirstOrDefault((n) => n.Index == node.ParentIndex);

                if (parent != null)
                {
                    node.Parent = parent;
                }
            }
        }
        
        private List<Node> FindHangingNodes(List<Node> nodes)
        {
            var hangingNodes = new List<Node>();
            
            foreach (var node in nodes)
            {
                if (node.IsTopLevelNode)
                {
                    node.IsHanging = false;
                }
                else
                {
                    if (node.Parent == null)
                    {
                        node.IsHanging = true;
                        hangingNodes.Add(node);
                    }
                    else
                    {
                        Node currentParent = node.Parent;

                        while (currentParent.Parent != null)
                        {
                            currentParent = currentParent.Parent;
                        }

                        if (!currentParent.IsTopLevelNode)
                        {
                            node.IsHanging = true;
                            hangingNodes.Add(node);
                        }
                        else
                        {
                            node.IsHanging = false;
                        }
                    }
                }
            }

            return hangingNodes;
        }
    }
}