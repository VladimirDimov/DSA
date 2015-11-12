namespace Marbles
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            var colors = Console.ReadLine();
            var numberOfColors = colors.Length;

            var diction = new Dictionary<char, int>();

            foreach (var color in colors)
            {
                if (diction.ContainsKey(color))
                {
                    diction[color] += 1;
                }
                else
                {
                    diction.Add(color, 1);
                }
            }

            BigInteger numberOfPermutations = Factorial(numberOfColors);

            foreach (var item in diction)
            {
                if (item.Value > 1)
                {
                    numberOfPermutations /= Factorial(item.Value);
                }
            }

            Console.WriteLine(numberOfPermutations);
        }

        static BigInteger Factorial(int number)
        {
            BigInteger result = 1;

            while (number != 1)
            {
                result *= (BigInteger)number;
                number--;
            }

            return result;
        }
    }
}
