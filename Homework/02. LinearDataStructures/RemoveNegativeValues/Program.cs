namespace RemoveNegativeValues
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var numbers = new int[] { 0, 1, -1, -2, 2, 3, -3, -3, 4, -4, 5, -5 };
            var positiveNumbers = RemoveNegativeNumbers(numbers);

            Console.WriteLine(string.Join(", ", positiveNumbers));
        }

        private static List<int> RemoveNegativeNumbers(int[] numbers)
        {
            var result = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] >= 0)
                {
                    result.Add(numbers[i]);
                }
            }

            return result;
        }
    }
}
