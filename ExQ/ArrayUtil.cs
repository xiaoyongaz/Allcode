using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class ArrayUtil
    {
        public static List<HashSet<int>> FindGroup(int[] input)
        {
            HashSet<int> visited = new HashSet<int>();
            List<HashSet<int>> groups = new List<HashSet<int>>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!visited.Contains(i))
                {
                    var current = i;
                    HashSet<int> newGroup = new HashSet<int>();
                    groups.Add(newGroup);
                    while (!visited.Contains(current))
                    {
                        visited.Add(current);
                        newGroup.Add(current);
                        current = input[current];
                    }
                }
            }

            return groups;
        }

        public static void TestFindGroup()
        { 
        }

        //condition: 
        public static void RegroupZero(int[] input)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == 0)
                {
                    BubbleUp(input, i);
                }
            }
        }
        
        //precondition: input[i] is 0, there is no addition 0 between nonzero after input[i] until end 0
        //postcondition: input[i] is bubbled up to end 0
        private static void BubbleUp(int[] input, int index)
        {
            while (index < (input.Length - 1) && input[index + 1] != 0)
            {
                input[index] = input[++index];
            }
            input[index] = 0;
        }

        public static void TestRearrangeZero()
        {
            int[][] positives = new int[][] { new int[] { }, new int[] { 0 }, new int[] { 0, 0, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[]{0, 1, 0, 1, 0},  };
            foreach (var positive in positives)
            {
                Console.WriteLine("before");
                PrintArray(positive);
                Console.WriteLine();
                RegroupZero(positive);
                Console.WriteLine("after");
                PrintArray(positive);
                Console.WriteLine();
            }

        }

        static Random rand = new Random();
        public static void QuickSort(int[] input, int start, int length)
        {
            if (length <= 1)
                return;
            var index = rand.Next(start + length);
            var temp = input[index];
            input[index] = input[start];
            input[start] = temp;
            var i = start;
            var j = start + length;
            while (true)
            {
                do
                {
                    i++;
                } while (i < j && input[i] < input[start] );
                do
                {
                    j--;
                } while (input[j] > input[start]);

                if (i > j)
                {
                    break;
                }
                temp = input[i];
                input[i] = input[j];
                input[j] = temp;
            }
            temp = input[start];
            input[start] = input[j];
            input[j] = temp;
            QuickSort(input, start, j - start);
            QuickSort(input, j + 1, length - j -1);
        }

        public static void QuickSortTest()
        {
            int[][] positives = new int[][] { new int[] { }, new int[] { 9 }, new int[] { 3, 4, 1, 2 }, new int[] { 1, 1, 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 3 } };
            foreach (var v in positives)
            {
                Console.WriteLine("before sort");
                PrintArray(v);
                Console.WriteLine();
                QuickSort(v, 0, v.Length);
                Console.WriteLine("after sort");
                PrintArray(v);
                Console.WriteLine();
            }
        }

        private static void PrintArray(int[] input)
        {
            foreach (var v in input) Console.Write("{0}:", v);
        }

        public static int BinarySearch(int[] input, int value, int start, int length)
        {
            if (length <= 0) return -1;
            var m = start + length/2;
            if (input[m] == value) return m;
            if (input[m] < value) return BinarySearch(input, value, start, length/2 -1);
            return BinarySearch(input, value, m + 1, length - length/2 -1);
        }
    }
}
