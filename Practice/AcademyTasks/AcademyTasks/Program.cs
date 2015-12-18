namespace AcademyTasks
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static int minSteps = int.MaxValue;
        static int target;
        static int[] bestByIndex;

        static void Main()
        {
            //var reader = new StreamReader("../../input/1.txt");
            //Console.SetIn(reader);

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            target = int.Parse(Console.ReadLine());

            bestByIndex = new int[numbers.Length];
            FindBestSolution(numbers, numbers[0], numbers[0]);
            Console.WriteLine(minSteps);
        }

        private static void FindBestSolution(int[] numbers, int min, int max, int left = 0, int steps = 1)
        {
            var current = numbers[left];
            if (steps >= minSteps)
            {
                return;
            }

            if (current < min)
            {
                min = current;
            }
            else if (current > max)
            {
                max = current;
            }

            if (max - min >= target)
            {
                if (minSteps > steps)
                {
                    minSteps = steps;
                }

                return;
            }

            if (left + 1 < numbers.Length)
            {
                FindBestSolution(numbers, min, max, left + 1, steps + 1);
            }
            if (left + 1 < numbers.Length - 1)
            {
                FindBestSolution(numbers, min, max, left + 2, steps + 1);
            }
        }
    }
}
