using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class Sort
    {
        public static void Qsort(int[] input, int start, int end)
        {
            if(start >= end)
                return;
            
            int pivot = input[start];
            int m = start;
            for (int i = m + 1; i <= end; i++)
            {
                if (input[i] < pivot)
                {
                    var temp = input[++m];
                    input[m] = input[i];
                    input[i] = temp;
                }
            }
            var temp2 = input[start];
            input[start] = input[m];
            input[m] = temp2;

            Qsort(input, start, m-1);
            Qsort(input, m+1, end);
        }

        public static void QsortLinkedList(Node start, Node end)
        {
            if(start == null || end == null || start == end)
                return;

            Node pre = start;
            Node current=pre.Next;
            Node middle = start;
            while (current!=null && current!=end.Next)
            {
                if (current.Value < start.Value)
                {
                    pre = middle;
                    middle = middle.Next;
                    var temp = middle.Value;
                    middle.Value = current.Value;
                    current.Value = temp;
                }
                current = current.Next;
            }

            var temp2 = start.Value;
            start.Value = middle.Value;
            middle.Value = temp2;

            QsortLinkedList(start, pre);
            QsortLinkedList(middle.Next, end);
        }

        public static void QuickSortTest()
        {
            int[] test = {4, 3, 2, 3};
            Qsort(test, 0, test.Length-1);
            int[][] positives = new int[][] { new int[] { }, new int[] { 9 }, new int[] { 3, 4, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 3 } };
            foreach (var v in positives)
            {
                Console.WriteLine("before sort");
                PrintArray(v);
                Console.WriteLine();
                Qsort(v, 0, v.Length-1);
                Console.WriteLine("after sort");
                PrintArray(v);
                Console.WriteLine();
            }
        }

        public static void QSortLinkedListTest()
        {
            int[][] positives = new int[][] { new int[] { }, new int[] { 9 }, new int[] { 3, 4, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 3 } };
            //int[][] positives = new int[][] { new int[] { 3, 4, 1, 2 }};
            foreach (var v in positives)
            {
                Node end;
                Node start = LinkedList.BuildLinkedList(v, out end);
                Console.WriteLine("before sort");
                LinkedList.WriteLinkedList(start);
                Console.WriteLine();
                QsortLinkedList(start, end);
                Console.WriteLine("after sort");
                LinkedList.WriteLinkedList(start);
                Console.WriteLine();
            }
   
        }
        private static void PrintArray(int[] input)
        {
            foreach (var v in input) Console.Write("{0}:", v);
        }

    }
}
