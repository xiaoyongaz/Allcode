using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    public class Expressions
    {
        static Dictionary<int, string> teens = new Dictionary<int, string>
                {
                    {2, "twenty"},
                    {3, "thirty"},
                    {4, "fourty"},
                    {5, "fifty"},
                    {6, "sixty"},
                    {7, "seventy"},
                    {8, "eighty"},
                    {9, "ninety"}
                };

        static Dictionary<int, string> singles = new Dictionary<int, string>
                {
                    {0, ""},
                    {1, "one"},
                    {2, "two"},
                    {3, "three"},
                    {4, "four"},
                    {5, "five"},
                    {6, "six"},
                    {7,"seven"},
                    {8, "eight"},
                    {9, "nine"}
                };

        static Dictionary<int, string> teen0 = new Dictionary<int, string>
                {
                    {10, "ten"},
                    {11, "eleven"},
                    {12, "twelve"},
                    {13, "thirteen"},
                    {14, "fourteen"},
                    {15, "fifteen"},
                    {16, "sixteen"},
                    {17, "seventeen"},
                    {18, "eighteen"},
                    {19, "nineteen"}
                };
        public static void Test()
        {
            ParameterExpression s = Expression.Parameter(typeof (string), "s");
            ParameterExpression a = Expression.Parameter(typeof (int), "a");
            ParameterExpression b = Expression.Parameter(typeof (int), "b");

            Expression<Func<string, int, int, string>> data = Expression.Lambda<Func<string, int, int, string>>(
                Expression.Call(s, typeof (string).GetMethod("Substring", new Type[] {typeof (int), typeof (int)}), a, b),
                s, a, b
                );

            Func<string, int, int, string> fun = data.Compile();
            Console.WriteLine(fun("Bart", 1, 2));
        }

        public static string itostr(long input)
        {
            string[] thusandsNames = {string.Empty, "thusand", "million", "billion", "trillion"};

            string result = string.Empty;
            var thusandIndex = 0;
            do
            {
                var thusandNumber = input%1000;
                input = input/1000;
                result = CovertThusand((int)thusandNumber) + thusandsNames[thusandIndex] + result;

            } while (thusandIndex++ < thusandsNames.Length && input != 0);

            if(input > 0)
                throw  new ArgumentOutOfRangeException(string.Format("{0} is out of range", input));

            return result;
        }

        private static string CovertThusand(int thusandNumber)
        {
            string result = string.Empty;
            if (thusandNumber > 99)
            {
                var hundred = thusandNumber/100;
                result = singles[hundred] + "hundred";
            }

            int belowHundred = thusandNumber%100;
            if (belowHundred > 19)
            {
                var tens = belowHundred / 10;
                var single = belowHundred % 10;
                result += teens[tens] + singles[single];
            }
            else if(belowHundred >=10)
            {
                result += teen0[belowHundred];
            }
            else
            {
                result += singles[belowHundred];
            }

            return result;
        }

        public static void ItoStrTest()
        {
            long[] values =
                {
                    0, 1, 3, 9, 10, 11, 15, 19, 20, 21, 99, 100, 101, 111, 199, 202, 212, 288, 999, 1000, 1001,
                    1010, 1145,34567890, 456780, 98706545321
                };

            foreach (var value in values)
            {
                Console.WriteLine(value);
                Console.WriteLine(itostr(value));
            }
        }
    }
}
