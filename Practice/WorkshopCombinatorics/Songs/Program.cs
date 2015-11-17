using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int inversions = 0;

            var array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                array2[i] = Array.IndexOf(array1, array2[i]);
            }

            for (int i = 0; i < n; i++)
            {
                if (array2[i] != i)
                {
                    inversions++;
                }
            }

            Console.WriteLine(inversions);
        }
    }
}
