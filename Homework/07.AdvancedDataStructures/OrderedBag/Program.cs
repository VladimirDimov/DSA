// Write a program to read a large collection of products (name + price) and efficiently find the 
// first 20 products in the price range [a…b].
//  Test for 500 000 products and 10 000 price searches.
//  Hint: you may use OrderedBag<T> and sub-ranges.

namespace OrderedBag
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    using System.Linq;
    using System;

    class Program
    {
        private const int NumberOfProducts = 500000;
        private const int NumberOfPriceSearches = 10000;

        private static RandomDataGenerator randomProductGenerator = new RandomDataGenerator();

        static void Main()
        {
            var randomProducts = GetRandomProducts(NumberOfProducts);

            var productFrom = new Product(null, 20);
            var productTo = new Product(null, 500);
            var productsInRange = randomProducts.Range(productFrom, true, productTo, true);

            var topProducts = productsInRange.Take(NumberOfPriceSearches);

            Console.WriteLine(string.Join(Environment.NewLine, topProducts));
        }

        private static OrderedBag<Product> GetRandomProducts(int numberOfProducts)
        {
            var result = new OrderedBag<Product>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                result.Add(new Product
                {
                    Name = randomProductGenerator.GetRandomString(3, 10),
                    Price = randomProductGenerator.GetRandomInt(1, 1000)
                });

            }

            return result;
        }
    }
}
