using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class Robot
    {
        public static int NumberOfPath(Tuple<int, int> start)
        {
            if (start.Item1 == 0) return 1;
            if (start.Item2 == 0) return 1;
            return NumberOfPath(new Tuple<int, int>(start.Item1 - 1, start.Item2)) +
                   NumberOfPath(new Tuple<int, int>(start.Item1, start.Item2 - 1));
        }
    }
}
