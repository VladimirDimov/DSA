namespace ZigZag
{
    using System;
    using System.Linq;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            var inputNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var n = inputNumbers[0];
            var k = inputNumbers[1];

            BigInteger result;
            result = (k - 1) * (k - 1) / 2 + 1;


            BigInteger variations = Factorial(n) / (Factorial(k) * Factorial(n - k));
            BigInteger finalRes = result * variations;

            Console.WriteLine(finalRes);
        }

        static BigInteger Factorial(int number)
        {
            BigInteger result = 1;

            while (number >= 1)
            {
                result *= (BigInteger)number;
                number--;
            }

            return result;
        }
    }
}
