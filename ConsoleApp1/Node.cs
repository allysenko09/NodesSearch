using System.Linq;

namespace ConsoleApp1
{
    public class Node
    {
        public string ParentIndex
        {
            get
            {
                if (IsTopLevelNode)
                {
                    return string.Empty;
                }
                else
                {
                    var array = Index.Split(".").ToList();
                    array.RemoveAt(array.Count - 1);
                    return string.Join(".", array);
                }
            }
        }

        public Node Parent { get; set; } 
        
        public string Index { get; set; }
        
        public string Name { get; set; }
        
        public bool IsHanging { get; set; }

        public bool IsTopLevelNode
        {
            get
            {
                return !Index.Contains(".");
            }
        }
    }
}