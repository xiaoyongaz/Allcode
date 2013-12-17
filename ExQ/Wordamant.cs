using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExQ
{
    class Wordamant
    {
        static HashSet<string> dictionary;
        static char[][] Puzzle;
        static Dictionary<string, List<Tuple<int,int>>> wordlist;
        static Dictionary<Tuple<int, int>, bool> visited;
        static List<Tuple<int, int>> moves;

        public static void FindAllWords()
        {
            moves = new List<Tuple<int, int>>();
            moves.Add(new Tuple<int, int>(-1, -1));
            moves.Add(new Tuple<int, int>(0, -1));
            moves.Add(new Tuple<int, int>(1, -1));
            moves.Add(new Tuple<int, int>(0, -1));
            moves.Add(new Tuple<int, int>(0, 1));
            moves.Add(new Tuple<int, int>(1, 1));
            moves.Add(new Tuple<int, int>(0, 1));
            moves.Add(new Tuple<int, int>(1, 1));
            for (int i = 0; i < Puzzle.Length; i++)
            {
                for (int j = 0; j < Puzzle.Length; j++)
                {
                    string a = new string(Puzzle[i][j], 1);
                    if (IsValidWordPrefix(a))
                    {
                        var path = new List<Tuple<int, int>>();
                        path.Add(new Tuple<int, int>(i, j));
                        Visit(a, path);
                    }
                }
            }
        }

        //given a currentStr and current Path, print all valid word 
        static void Visit(string currentStr, List<Tuple<int, int>> currentPath)
        {
            if (dictionary.Contains(currentStr))
            {
                PrintWord(currentStr, currentPath);
            }

            Tuple<int, int> currentLocation = currentPath.Last();
            foreach (var move in moves)
            {
                int newX = currentLocation.Item1 + move.Item1;
                int newY = currentLocation.Item2 + move.Item2;
                Tuple<int, int> newLocation = new Tuple<int, int>(newX, newY);
                if (!currentPath.Contains(newLocation) && (newX >= 0 && newX < Puzzle.Length) && (newY >= 0 && newY < Puzzle.Length))
                {
                    string newStr = currentStr + Puzzle[newX][newY];
                    List<Tuple<int, int>> newPath = new List<Tuple<int, int>>(currentPath);
                    newPath.Add(newLocation);
                    Visit(newStr, newPath);
                }
            }

        }

        private static void PrintWord(string currentStr, List<Tuple<int, int>> currentPath)
        {
            Console.WriteLine("find word {0}", currentStr);
            Console.WriteLine("path is :");
            foreach (var p in currentPath)
            {
                Console.Write("({0},{1})->", p.Item1, p.Item2);
            }
        }

        
        static bool IsValidWordPrefix(string word)
        {
            foreach (var v in dictionary)
            {
                if (v.StartsWith(word))
                    return true;
            }

            return false;
        }
    }
}
