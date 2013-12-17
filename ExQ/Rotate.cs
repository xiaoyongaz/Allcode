using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class Rotate
    {
        public static void Do(char[] toRotate, int offset)
        {
            if (toRotate == null || toRotate.Length <= 1)
                return;

            if (toRotate.Length < offset)
            {
                Console.WriteLine("error: offset is too large");
                return;
            }

            Turn(toRotate, 0, offset - 1);
            Turn(toRotate, offset, toRotate.Length-1);
            Turn(toRotate, 0, toRotate.Length -1);
        }

        private static void Turn(char[] toRotate, int i, int i1)
        {
            char temp;
            while (i<i1)
            {
                temp = toRotate[i];
                toRotate[i] = toRotate[i1];
                toRotate[i1] = temp;
                i++;
                i1--;
            }
        }

        public static void RotateTest()
        {
            char[] test1 = {'a'};
            Do(test1, 1);
            Print(test1);
            char[] test2 = {'a', 'b', 'c', 'd', 'e', 'f', 'g'};
            Do(test2,3);
            Print(test2);
        }

        private static void Print(char[] test1)
        {
            Console.WriteLine("-------------------------------------------------");
            foreach (var v in test1)
            {
                Console.WriteLine(v);
            }
        }
    }
}
