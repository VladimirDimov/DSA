using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        static List<string> solutions = new List<string>();
        static int length;

        static void Main()
        {
            var input = Console.ReadLine();
            length = input.Length;

            BuildCombinations(input, 0, string.Empty);

            Console.WriteLine(solutions.Count);
            Console.WriteLine(string.Join(Environment.NewLine, solutions));
        }

        static void BuildCombinations(string input, int index, string current)
        {
            if (index == length)
            {
                solutions.Add(current);
                return;
            }

            if (input[index] == '*')
            {
                BuildCombinations(input, index+1, string.Format("{0}{1}", current, 'L'));
                BuildCombinations(input, index+1, string.Format("{0}{1}", current, 'R'));
                BuildCombinations(input, index+1, string.Format("{0}{1}", current, 'S'));
            }
            else
            {
                BuildCombinations(input, index+1, string.Format("{0}{1}", current, input[index]));                
            }
        }
    }
}
