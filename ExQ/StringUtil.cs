using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class StringUtil
    {
        public static bool HasDuplicateChars(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            var distinct = input.Distinct();
            return input.Length == distinct.Count();
        }

        public static void Test1()
        { 
            string[] positives = {"", " ", "a", "abc"};
            string[] negatives = {"  ", "aa", "aba"};
            Console.WriteLine("should be true below");
            foreach(var str in positives)
            {
                Console.WriteLine(HasDuplicateChars(str));
            }

            Console.WriteLine("should be false below");
            foreach (var str in negatives)
            {
                Console.WriteLine(HasDuplicateChars(str));
            }
        }

        //if in c, need to consider safe array handling
        public static void ReverseString(char[] input)
        {
            if (input == null)
            {
                return;
            }

            int count = 0;
            while (input[count++] != 0) ;
            count--;count--;
            int start = 0;
            while (start < count)
            {
                var temp = input[start];
                input[start] = input[count];
                input[count] = temp;
                start++; count--;
            }
            
        }

        public static void TestReverseString()
        {
            char[][] positives = { null, new char[]{(char)0}, new char[]{'a', (char)0}, new char[]{'a', 'b', (char)0}, new char[]{'a', 'b', 'c' ,(char)0}};
            char[][] negatives = { new char[] {'a'}};

            Console.WriteLine("should be good");
            foreach(var charry in positives)
            {
                WriteCharArray(charry);
                ReverseString(charry);
                WriteCharArray(charry);
            }

            Console.WriteLine("negative case");
            foreach (var charry in negatives)
            {
                WriteCharArray(charry);
                ReverseString(charry);
                WriteCharArray(charry);
            }
            return;
        }

        public static void WriteCharArray(char[] input)
        {
            if (input == null)
            {
                Console.WriteLine("null char array");
                return;
            }

            foreach(var c in input)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        //support positive/negative number
        //throw invalid format exception
        //throw overflow exeception
        public static int AtoI(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("input is null or empty");

            int result = 0;
            bool isNegative = false;
            int index = 0;
            if (input[index] == '-')
            {
                isNegative = true;
                index++;
            }
            while (index < input.Length)
            {
                if (input[index] < '0' || input[index] > '9')
                {
                    throw new ArgumentException(string.Format("{0} contains non number char {1} at position {2}", input, input[index], index));
                }
                result = result * 10 + input[index] - '0';
                index++;
            }

            return isNegative ? -1*result : result;
        }

        public static void AtoITest()
        {
            string[] positives = { "0", "10", "000", "001", "123", "0950", "-5" };
            string[] negatives = { null, "", "abc", "123a" };

            foreach (var s in positives)
            {
                Console.WriteLine("{0} convert to {1}", s, AtoI(s));
            }

            foreach (var s in negatives)
            {
                try
                {
                    Console.WriteLine("try convert {0}", s);
                    AtoI(s);
                }
                catch (Exception e)
                {
                    Console.WriteLine("get exception {0}", e.Message);
                }

            }
        }

        public static bool IsASentence(string input, HashSet<string> dictionary)
        {
            bool isSentence = false;

            foreach (var word in dictionary)
            {
                if (input.StartsWith(word))
                {
                    if(input.Length == word.Length)
                    return true;
                    isSentence |= IsASentence(input.Substring(word.Length), dictionary);
                }

                if (isSentence)
                    return true;
            }
            return false;
        }
    }
}
