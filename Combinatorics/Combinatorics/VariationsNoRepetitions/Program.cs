using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariationsNoRepetitions
{
    class Program
    {

        static void Main()
        {
            int n = 3;
            int k = 2;

            string[] objects = new string[] { "A", "B", "C" };
            bool[] used = new bool[n];

            var result = new List<string[]>();
            GenerateVariationsNoRepetitions(objects, n, k, new int[k], new bool[n], result);

            foreach (var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void GenerateVariationsNoRepetitions(string[] objects, int n, int k, int[] currentVariation, bool[] used, List<string[]> result, int index = 0)
        {
            if (index >= k)
            {
                result.Add(currentVariation.Select(x => objects[x]).ToArray());
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentVariation[index] = i;
                        GenerateVariationsNoRepetitions(objects, n, k, currentVariation, used, result, index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
