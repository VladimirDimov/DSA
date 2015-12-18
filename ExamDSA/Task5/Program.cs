namespace Task5
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    class Program
    {
        static int minWidth;
        static int left = 0;
        static int right = 0;

        static void Main()
        {
            var reader = new StreamReader("../../input/1.txt");
            Console.SetIn(reader);

            var passwordLength = int.Parse(Console.ReadLine());
            var directions = Console.ReadLine();

            for (int i = 0; i < passwordLength - 1; i++)
            {
                var direction = directions[i];
                if (direction == '<')
                {
                    minWidth--;
                    if (left > minWidth)
                    {
                        left = minWidth;
                    }
                }
                else if (direction == '>')
                {
                    minWidth++;
                    if (right < minWidth)
                    {
                        right = minWidth;
                    }
                }                
            }

            minWidth = right - left + 1;

            var minLeft = passwordLength - minWidth;

        }

        private static void DecreaseMaxNumber(int[] maxNumberByPosition, int index)
        {
            for (int i = 0; i <= index; i++)
            {
                maxNumberByPosition[i]--;
            }
        }

        private static void IncreaseMaxNumber(int[] maxNumberByPosition, int index)
        {
            for (int i = index; i < maxNumberByPosition.Length; i++)
            {
                maxNumberByPosition[i]++;
            }
        }
    }
}
