using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class CodeEval_seq
    {
        static void PrintSeq()
        {
            Console.WriteLine("Enter the file name for parameters");
            var fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine(string.Format("cannot find the file {0}", fileName));
                Console.WriteLine("current working directory is " + Environment.CurrentDirectory);
                return;
            }
            var input = File.ReadLines(fileName);
            if (input != null)
            {
                foreach (var line in input)
                {
                    var inputs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (inputs != null && inputs.Length != 3)
                    {
                        Console.WriteLine("we need three parameter");
                    }
                }
            }
        }
    }
}
