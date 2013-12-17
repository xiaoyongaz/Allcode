using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class GraphNode
    {
        int Value { set; get; }
        public List<GraphNode> Links { set; get; }
    }
    class Graph
    {
        public static bool HasPathBreadthFirst(GraphNode node1, GraphNode node2)
        {
            if (node1 == null || node2 == null) return false;
            Queue<GraphNode> nodes = new Queue<GraphNode>();
            HashSet<GraphNode> visitedNodes = new HashSet<GraphNode>();
            nodes.Enqueue(node1);
            while (nodes.Any())
            {
                var v = nodes.Dequeue();
                if (v == node2)
                    return true;
                visitedNodes.Add(v);
                foreach (var n in v.Links)
                {
                    if(!visitedNodes.Contains(v))
                        nodes.Enqueue(n);
                }
            }

            return false;
        }

        public static void TestPath()
        {
            
        }

        public static GraphNode Graph1
        {
            get { return null; }
        }
    }
}
