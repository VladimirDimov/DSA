//A large trade company has millions of articles, each described by barcode, vendor, title and price.
//Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y].
//Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.
namespace OrderedMultidictionary
{
    using OrderedMultidictionary.Data;
    using OrderedMultidictionary.Services;
    using System;

    class Program
    {
        static void Main()
        {
            var randomArticlesGenerator = new RandomArticlesGenerator();
            var articles = randomArticlesGenerator.GetRandomArticlesCollection(1000);

            while (true)
            {
                Console.Write("Enter min price: ");
                var minPrice = int.Parse(Console.ReadLine());

                Console.Write("Enter max price: ");
                var maxPrice = int.Parse(Console.ReadLine());

                Console.WriteLine("Prices in the range {0} to {1}", minPrice, maxPrice);
                var articlesInRange = articles.Range(minPrice, true, maxPrice, true);
                Console.WriteLine(string.Join(Environment.NewLine, articlesInRange.Values));
            }
        }
    }
}
