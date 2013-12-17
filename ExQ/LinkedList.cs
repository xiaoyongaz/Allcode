using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class Node2Link
    {
        public int Value { get; set; }
        public Node2Link Next { get; set; }
        public Node2Link Random { get; set; }
    }

    class LinkedList
    {
        public Node Head { get; set; }

        public static Node BuildLinkedList(int[] input)
        {
            Node head = null;
            if (input == null || input.Length < 1)
            {
                return head;
            }

            head = new Node();
            var tail = head;
            var pre = head;
            foreach (var v in input)
            {
                pre = tail;
                tail.Value = v;
                tail.Next = new Node();
                tail = tail.Next;
            }

            pre.Next = null;
            return head;
        }

        public static Node BuildLinkedList(int[] input, out Node end)
        {
            if (input == null || input.Length < 1)
            {
                end = null;
                return null;
            }

            Node head = new Node();
            var tail = head;
            var pre = head;
            foreach (var v in input)
            {
                pre = tail;
                tail.Value = v;
                tail.Next = new Node();
                tail = tail.Next;
            }

            pre.Next = null;
            end = pre;
            return head;
        }

        public static Node BuildLinkedList2(int[] input)
        {
            Node head = null;
            if (input == null || input.Length < 1)
            {
                return head;
            }

            Node preHead;
            foreach (var v in input)
            {
                preHead = head;
                head = new Node() { Value = v, Next = preHead };
            }
            return head;
        }

        public static void WriteLinkedList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.Value);
                if (head.Next != null)
                {
                    Console.Write("->");
                }
                head = head.Next;
            }
            Console.WriteLine();
        }

        public static void InsertToHead(ref Node head)
        {

        }

        public static void RemoveDuplicate(Node head)
        {
            if (head == null) return;

            HashSet<int> values = new HashSet<int>();
            Node pre = head;
            while (head != null)
            {
                if (values.Contains(head.Value))
                {
                    pre.Next = head.Next;
                    head = head.Next;
                }
                else
                {
                    values.Add(head.Value);
                    pre = head;
                    head = head.Next;
                }
            }
        }

        public static void TestRemoveDup()
        {
            int[][] positives = new int[][] { new int[] { 1, 1 }, new int[] { 1, 2, 1 }, new int[] { 1, 1, 1 }, new int[] { 1, 2, 3, 3, 3 } };
            foreach (var t in positives)
            {
                Node n = BuildLinkedList2(t);
                Console.WriteLine("before remove");
                WriteLinkedList(n);
                RemoveDuplicate(n);
                Console.WriteLine("post remove");
                WriteLinkedList(n);
            }
        }

        public static Node2Link DeepCopy(Node2Link head, Dictionary<int, Node2Link> nodeMap)
        {
            if (head == null)
                return head;


            var hash = head.GetHashCode();
            Node2Link newNode = new Node2Link();
            newNode.Value = head.Value;
            nodeMap.Add(hash, newNode);

            newNode.Next = DeepCopy(head.Next, nodeMap);
            var randomHash = head.Random.GetHashCode();
            newNode.Random = nodeMap[randomHash];
            return newNode;
        }

        public static void QuickSort(Node head, Node tail)
        {
            if (head == tail)
                return;

            var oldHead = head;
            var l = head;
            while (l != tail)
            {
                while (l.Value <= head.Value && l != tail)
                {
                    l = l.Next;
                }

                var r = l;
                while (r.Value > head.Value && r != null)
                {
                    r = r.Next;
                }

            }
        }
    }
}
