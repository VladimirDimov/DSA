namespace AlgoTaskOne
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            long[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            var a = input[0];
            var b = input[1];
            var c = input[2];
            var n = input[3];

            Console.WriteLine(Tribonacci(a, b, c, n));
        }

        static long Tribonacci(long a, long b, long c, long n)
        {
            if (n == 1)
            {
                return a;
            }
            else if (n == 2)
            {
                return b;
            }
            else if (n == 3)
            {
                return c;
            }

            long counter = 3;
            long result = 0;
            while (counter < n)
            {
                result = a + b + c;
                a = b;
                b = c;
                c = result;
                counter++;
            }

            return result;
        }
    }
}

