namespace Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var reader = new StreamReader("../../input/2.txt");
            int maxWeight = 0;
            Console.SetIn(reader);
            var products = new List<Product>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine().Trim().ToLower();
                Console.WriteLine(line);

                if (line.StartsWith("weight"))
                {
                    maxWeight = int.Parse(line.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray()[1]);
                    continue;
                }

                var productValues = line
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

            int numberOfProducts = products.Count;

            var solutionArr = new int[numberOfProducts, maxWeight + 1];
            var pickupTrack = new int[numberOfProducts, maxWeight + 1];

            products = products
                .OrderBy(p => p.Weight)
                .ToList();

            for (int row = 0; row < numberOfProducts; row++)
            {
                for (int col = 1; col <= maxWeight; col++)
                {

                    var curProduct = products[row];
                    var curWeight = curProduct.Weight;
                    var curCost = curProduct.Cost;

                    var upperCost = row != 0 ? solutionArr[row - 1, col] : 0;

                    if (curWeight > col)
                    {
                        solutionArr[row, col] = upperCost;
                        pickupTrack[row, col] = -1;
                    }
                    else
                    {
                        var upperLeftCost = row != 0 ? solutionArr[row - 1, col - curWeight] : 0;
                        var newCost = curCost + upperLeftCost;

                        if (upperCost <= newCost)
                        {
                            solutionArr[row, col] = newCost;
                            pickupTrack[row, col] = 1;
                        }
                        else
                        {
                            solutionArr[row, col] = upperCost;
                            pickupTrack[row, col] = -1;
                        }
                    }
                }
            }

            Console.WriteLine();
            ArrayConsolePrinter.Print(solutionArr);
            Console.WriteLine();
            ArrayConsolePrinter.Print(pickupTrack);

            var productsFromSolution = GetProductsFromSolution(pickupTrack, products);

            Console.WriteLine();
            foreach (var product in productsFromSolution)
            {
                Console.WriteLine("{0} -> weight = {1}, cost = {2}", product.Name, product.Weight, product.Cost);
            }
            Console.WriteLine("Total cost: {0}", solutionArr[numberOfProducts - 1, maxWeight]);
        }

        static IList<Product> GetProductsFromSolution(int[,] track, IList<Product> products)
        {
            var result = new List<Product>();

            int row = track.GetLength(0) - 1;
            int col = track.GetLength(1) - 1;
            while (row >= 0 && col >= 0)
            {
                var product = products[row];
                if (track[row, col] == 1)
                {
                    result.Add(products[row]);
                    col = col - product.Weight;
                }
                else
                {
                    row--;
                }
            }

            return result;
        }
    }
}
