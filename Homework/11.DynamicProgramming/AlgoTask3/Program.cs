namespace AlgoTaskSix
{
    using System;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            var countOfNumbers = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            var initialValue = int.Parse(Console.ReadLine());
            var maxValue = int.Parse(Console.ReadLine());

            var table = new int[countOfNumbers + 1, maxValue + 1];
            table[0, initialValue] = 1;

            for (int row = 1; row <= countOfNumbers; row++)
            {
                for (int col = 0; col <= maxValue; col++)
                {
                    if (table[row - 1, col] == 1)
                    {
                        if (col - numbers[row - 1] >= 0)
                        {
                            table[row, col - numbers[row - 1]] = 1;
                        }
                        if (col + numbers[row - 1] <= maxValue)
                        {
                            table[row, col + numbers[row - 1]] = 1;
                        }
                    }
                }
            }

            for (int i = maxValue; i >= 0; i--)
            {
                if (table[countOfNumbers, i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}