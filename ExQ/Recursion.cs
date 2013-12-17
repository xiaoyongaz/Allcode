using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class Recursion
    {
        // if just count the number
        public static int WaysToGoUp(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (n == 3) return 4;

            return WaysToGoUp(n - 1) + WaysToGoUp(n - 2) + WaysToGoUp(n - 3);
        }

        //print the path also
        // if just count the number
        public static int WaysToGoUp2(int n, List<int> steps)
        {
            if (n <= 0)
            {
                PrintList(steps);
                return 1; 
            }
            if (n == 1)
            {
                var a = new List<int>(steps);
                a.Add(1);
                return WaysToGoUp2(0, a);
            }
            if (n == 2)
            {
                var a = new List<int>(steps);
                a.Add(1);

                var b = new List<int>(steps);
                b.Add(2);
                return WaysToGoUp2(n - 1, a) + WaysToGoUp2(n - 2, b);
            }

            var a1 = new List<int>(steps);
            a1.Add(1);
            var b1 = new List<int>(steps);
            b1.Add(2);
            var c1 = new List<int>(steps);
            c1.Add(3);

            return WaysToGoUp2(n - 1, a1) + WaysToGoUp2(n - 2,b1) + WaysToGoUp2(n - 3,c1);
        }

        private static void PrintList(List<int> steps)
        {
            foreach (var v in steps)
            {
                Console.Write("{0}:", v);
            }
            Console.WriteLine();
        }

        public static void TestSteps()
        {
            for (int i = 0; i < 10; i++)
            {
                var t = WaysToGoUp2(i, new List<int>());
                Console.WriteLine("{0} has {1} way of going up", i, t);
            }
        }
        //using dynamic programming

        public static int WaysToSum(int numberOfv, int sum, List<int> sequence)
        {
            if (numberOfv == 0 || sum == 0)
                return 0;
            if (numberOfv == 1)
            {
                sequence.Add(sum);
                PrintList(sequence);
                return 1;
            }

            int ways = 0;
            int first = 1;
            while (first < sum)
            {
                var newSeq = new List<int>(sequence);
                newSeq.Add(first);
                ways += WaysToSum(numberOfv - 1, sum - first, newSeq);
                first++;
            }

            return ways;
        }

        public static void TestSum()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    var total = WaysToSum(j, i, new List<int>());
                    Console.WriteLine("there are {0} ways to sum {1} using {2} variables", total, i, j);
                }
            }
        }
    }
}
