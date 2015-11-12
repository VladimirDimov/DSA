namespace ColorRabbits
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var numberOfRabbits = int.Parse(Console.ReadLine());
            var rabbitsDiction = new Dictionary<ulong, ulong>();

            for (int i = 0; i < numberOfRabbits; i++)
            {
                var currentAnswer = ulong.Parse(Console.ReadLine());
                if (rabbitsDiction.ContainsKey(currentAnswer))
                {
                    rabbitsDiction[currentAnswer]++;
                }
                else
                {
                    rabbitsDiction[currentAnswer] = 1;
                }
            }

            ulong counter = 0;
            foreach (var item in rabbitsDiction)
            {
                ulong answer = item.Key;
                ulong numberOfAsked = item.Value;

                counter += (ulong)Math.Ceiling((decimal)numberOfAsked / (answer + 1)) * (answer + 1);
            }

            Console.WriteLine(counter);
        }
    }
}