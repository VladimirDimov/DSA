namespace ColorBalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var groups = new int[26];
            foreach (var ball in input)
            {
                groups[ball - 'A']++;
            }

            int n = input.Length;

            var factorials = new long[2 * n];
            factorials[0] = 1;

            for (int i = 0; i < 2 * n - 1; i++)
            {
                factorials[i + 1] = factorials[i] * (factorials[i] + 1);
            }

            var result = (factorials[2 * n - 1] / factorials[n + 1]);

            foreach (var gr in groups)
            {
                result /= gr;
            }

            Console.WriteLine(result);
        }
    }
}
