using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class BTree
    {
        public BTree Root;
        BTree Left;
        BTree Right;
        BTree Next;
        int Value { set; get; }
        Queue<int> discoveredNodes = new Queue<int>();

        public static void Insert(ref BTree root, int value)
        {
            if (root == null)
            {
                root = new BTree() { Value = value };
                return;
            }

            if (value < root.Value)
            {
                Insert(ref root.Left, value);
            }
            else if (value > root.Value)
            {
                Insert(ref root.Right, value);
            }
            else
            {
                Console.WriteLine("duplicated value {0} skipped", value);
            }
        }
        
        public static void PreTraverse(BTree root)
        {
            if(root == null) return;

            Console.WriteLine("visiting node {0}", root.Value);

            PreTraverse(root.Left);
            PreTraverse(root.Right);
        }

        public static void PostTraverse(BTree root)
        { 
            if(root == null) return;

            PostTraverse(root.Left);
            PostTraverse(root.Right);
            Console.WriteLine("visiting node {0}", root.Value);
        }

        public static void InTraverse(BTree root)
        {
            if (root == null) return;

            PostTraverse(root.Left);
            Console.WriteLine("visiting node {0}", root.Value);
            PostTraverse(root.Right);
        }

        //public void LevelTraverse()
        //{ 
        //    discoveredNodes.Enqueue(
        //}

        public static bool Find(int value)
        {
            return false;    
        }

        public static bool IsBalanced(BTree root, out int depth)
        {
            if (root == null)
            {
                depth = 0;
                return true;
            }
            int ld;
            var l = IsBalanced(root.Left, out ld);
            int rd;
            var r = IsBalanced(root.Right, out rd);
            int diff = 0;
            if (ld < rd) { diff = rd - ld; depth = rd; }
            else{ diff = ld -rd;depth = ld;}
            return diff <= 1;
        }

        public static string SerializeTree(BTree root)
        {
            if (root == null)
            {
                return string.Empty;
            }
            return root.Value + "(" + SerializeTree(root.Left) + "," + SerializeTree(root.Right);
        }

        // Tree = Node ( Tree, Tree) | Node  
        public static BTree DeserializeTree(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return null;
            }
            int index = format.IndexOf('(');
            int middle = 0;
            string value;
            if (index > 0)
            {
                value = format.Substring(0, index);
                middle = FindMiddleIndex(format.Substring(index + 1, format.Length - index - 2));
            }
            else
            {
                value = format.Trim();
            }

            BTree node = new BTree();
            int v;
            if (int.TryParse(value, out v))
            {
                node.Value = v;
            }
            if (middle == 0)
                return node;

            BTree lnode = DeserializeTree(format.Substring(index + 1, middle - index - 1));
            BTree rnode = DeserializeTree(format.Substring(middle + 1, format.Length - 2 - middle));
            node.Left = lnode;
            node.Right = rnode;
            return node;
            
        }

        private static int FindMiddleIndex(string format)
        {
            int depth = 0;
            for(int i=0; i< format.Length; i++)
            {
                if (format[i] == '(') depth++;
                if ( format[i]== ')') depth--;
                if (format[i] == ',' && depth == 0)
                    return i;
            }
                
            return 0;
        }

        //array of tree nodes, determine whether it forms a b-tree
        //assumption1, there is no loop, it's tree node,not a graph
        public static bool IsTree(BTree[] nodes)
        {
            //node : number of node in the tree
            var visitedNodes = new Dictionary<BTree,int>();
            foreach (var v in nodes)
            {
                if(!visitedNodes.ContainsKey(v))
                {
                    var number = TraverseT(v, new List<BTree>(), visitedNodes);
                    visitedNodes[v] = number;
                }
            }

            return nodes.Any(v => visitedNodes[v] == nodes.Length);
        }

        static int TraverseT(BTree node, List<BTree> currentTree, Dictionary<BTree, int> visitedNodes)
        {
            if (node == null)
            {
                return 0;
            }

            if (visitedNodes.ContainsKey(node))
            {
                return visitedNodes[node];
            }

            currentTree.Add(node);
            var number = TraverseT(node.Left, currentTree, visitedNodes) + TraverseT(node.Right, currentTree, visitedNodes);
            visitedNodes.Add(node, number + 1);
            return number + 1;
        }

        //add next 1, using level or BFS traverse
        public static void AddNext(BTree root)
        {
            Queue<Tuple<BTree, int>> queue = new Queue<Tuple<BTree, int>>();
            queue.Enqueue(new Tuple<BTree, int>(root, 0));
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Item1.Left != null)
                {
                    queue.Enqueue(new Tuple<BTree,int>(node.Item1.Left, node.Item2 +1));
                }
                if (node.Item1.Right != null)
                {
                    queue.Enqueue(new Tuple<BTree, int>(node.Item1.Right, node.Item2 + 1));
                }
                if (node.Item2 == queue.Peek().Item2)
                    node.Item1.Next = queue.Peek().Item1;
            }
        }

        public static void AddNextNoExtra(BTree root)
        {
            AddNextNoExtraWorker(null, root);
        }

        public static void AddNextNoExtraWorker(BTree pre, BTree node)
        {
            if (node == null) return;
            if (pre != null) pre.Next = node;

            if (pre != null)
            {
                AddNextNoExtraWorker(pre.Right, node.Left);
            }
            else
            {
                AddNextNoExtraWorker(null, node.Left);
            }

            AddNextNoExtraWorker(node.Left, node.Right);
        }

        //if only p in tree return p
        //if only q in tree return q
        //if neither in tree return null
        //if both in tree, return the common ancester
        public static BTree FindCommonAncester(BTree root, BTree node1, BTree node2)
        {
            if (root == null) return null;
            if (root == node1 || root == node2) return root;
            var leftAncestor = FindCommonAncester(root.Left, node1, node2);
            var rightAncester = FindCommonAncester(root.Right, node1, node2);
            return null;
        }
    }
}
