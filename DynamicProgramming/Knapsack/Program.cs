namespace Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var reader = new StreamReader("../../input/1.txt");
            Console.SetIn(reader);
            var products = new List<Product>();
            while (!reader.EndOfStream)
            {
                var productValues = reader
                    .ReadLine()
                    .Split(new char[] { '–' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var values = productValues[1]
                    .Split(new char[] { '=', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var weight = int.Parse(values[1]);
                var cost = int.Parse(values[3]);

                products.Add(new Product
                {
                    Name = productValues[0],
                    Weight = int.Parse(values[1]),
                    Cost = int.Parse(values[3])
                });
            }

            int maxWeight = 9;
            int numberOfProducts = products.Count;

            var solutionArr = new int[numberOfProducts, maxWeight];
            var pickupTeackArr = new int[numberOfProducts, maxWeight];

            products = products
                .OrderBy(p => p.Weight)
                .ToList();            
        }
    }
}
