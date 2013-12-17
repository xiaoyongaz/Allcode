using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //Math.TestFib();
            //TestHeap();
            //Rotate.RotateTest();
            //Expressions.Test();
            //StringUtil.Test1();
            //StringUtil.TestReverseString();
            //LinkedList.TestRemoveDup();
            //Recursion.TestSteps();
            //StringUtil.AtoITest();
            //Recursion.TestSum();
            //ListTupleTest();
            //ArrayUtil.QuickSortTest();
            //Queue.EnqeueDequeueTest();
            //ArrayUtil.TestRearrangeZero();
            //Expressions.ItoStrTest();
            //Sort.QuickSortTest();
            Sort.QSortLinkedListTest();
        }

        private static void ListTupleTest()
        {
            List<Tuple<int, int>> listtuple = new List<Tuple<int, int>>();
            listtuple.Add(new Tuple<int, int>(1, 1));
            listtuple.Add(new Tuple<int, int>(2, 2));
            Tuple<int, int> tuple = new Tuple<int, int>(1, 1);
            Console.WriteLine("tuple contains (1,1) is {0}", listtuple.Contains(tuple));
        }
        private static int Count(int n)
        {
            var r = 0;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j <= n; j++)
                    for (int k = 1; k <= j; k++)
                        r++;
            return r;
        }

        static void TestHeap()
        {
            var heap = new Heap(20);
            var value = new int[10] {3, 4, 1, 5, 2, 7, 11, 22, 0, 33};
            foreach (var i in value)
            {
                heap.Append(i);
                heap.SifUp();
            }

            heap.Dump();
        }
    }

    static class Math
    {
        public static uint Fib(uint n)
        {
            if (n < 3)
            {
                return 1;
            }
            uint p1 = 1;
            uint p2 = 1;
            uint index = 2;
            uint temp = p1 + p2;
            while (index < n)
            {
                temp = p1 + p2;
                p1 = p2;
                p2 = temp;
                index++;
            }

            return temp;
        }

        public static void TestFib()
        {
            for (uint i = 0; i < 10; i++)
            {
                Console.WriteLine("fib {0} is {1}", i, Fib(i));
            }
        }
    }

    public class Heap
    {
        private readonly int[] elements;
        private int end;

        public Heap(int size)
        {
            elements = new int[size+1];
            end = 1;
        }

        public Heap(int[] values, int end)
        {
            elements = values;
            this.end = end;
        }

        public void Append(int value)
        {
            if (end == elements.Length)
            {
                Console.WriteLine("container size limit reached");
            }
            elements[end++] = value;
        }

        public void SifUp()
        {
            var parent = (end -1) / 2;
            var current = end - 1 ;
            while (current > 1 && elements[parent] > elements[current])
            {
                var t = elements[parent];
                elements[parent] = elements[current];
                elements[current] = t;
                current = parent;
                parent = parent >> 1;
            }
        }

        public void SiftDown(){}

        public void Dump()
        {
            for (int index = 1; index < end; index++)
            {
                var element = elements[index];
                Console.WriteLine(element);
            }
        }
    }
}
