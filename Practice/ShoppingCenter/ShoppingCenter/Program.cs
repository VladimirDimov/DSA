namespace ShoppingCenter
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
        private const string AddProduct = "AddProduct";
        private const string FindProductsByName = "FindProductsByName";
        private const string FindProductsByProducer = "FindProductsByProducer";
        private const string FindProductsByPriceRange = "FindProductsByPriceRange";
        private const string DeleteProducts = "DeleteProducts";

        private const string ProductAdded = "Product added";
        private const string NoProductsFound = "No products found";

        static StringBuilder result = new StringBuilder();
        static MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> byProducer = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> byProducerName = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> byProductNameProducer = new MultiDictionary<string, Product>(true);
        static OrderedMultiDictionary<decimal, Product> byPrice = new OrderedMultiDictionary<decimal, Product>(true);

        static void Main()
        {
            //var reader = new StreamReader("../../1.txt");
            //Console.SetIn(reader);

            var numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                var line = Console.ReadLine();
                if (line.StartsWith(AddProduct))
                {
                    var commandParams = line
                        .Substring(AddProduct.Length)
                        .Trim()
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    result.AppendLine(ExecuteAddProduct(commandParams));
                }
                else if (line.StartsWith(FindProductsByName))
                {
                    var commandParam = line
                        .Substring(FindProductsByName.Length)
                        .Trim();

                    result.AppendLine(ExecuteFindProductsByName(commandParam));
                }
                else if (line.StartsWith(FindProductsByProducer))
                {
                    var commandParam = line
                        .Substring(FindProductsByProducer.Length)
                        .Trim();

                    result.AppendLine(ExecuteFindProductsByProducer(commandParam));
                }
                else if (line.StartsWith(FindProductsByPriceRange))
                {
                    var commandParams = line
                        .Substring(FindProductsByPriceRange.Length)
                        .Trim()
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => decimal.Parse(x))
                        .ToArray();

                    result.AppendLine(ExecuteFindProductsByPriceRange(commandParams));
                }
                else if (line.StartsWith(DeleteProducts))
                {
                    var commandParams = line
                        .Substring(DeleteProducts.Length)
                        .Trim()
                        .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    if (commandParams.Length == 1)
                    {
                        result.AppendLine(ExecuteDeleteByProducer(commandParams[0]));
                    }
                    else if (commandParams.Length == 2)
                    {
                        result.AppendLine(ExecuteDeleteByProducerProductName(commandParams));
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static string ExecuteDeleteByProducerProductName(string[] commandParams)
        {
            var searchKey = string.Join(";", commandParams);
            var productsToDelete = byProductNameProducer[searchKey].ToArray();

            if (productsToDelete.Length != 0)
            {
                foreach (var product in productsToDelete)
                {
                    byProducer.Remove(product.Producer, product);
                    byPrice.Remove(product.Price, product);
                    byName.Remove(product.Name, product);
                    byProductNameProducer.Remove(searchKey);
                }

                return string.Format("{0} products deleted", productsToDelete.Length);
            }
            else
            {
                return NoProductsFound;
            }
        }

        private static string ExecuteDeleteByProducer(string producer)
        {
            var productsToDelete = byProducer[producer].ToArray();

            if (productsToDelete.Length != 0)
            {
                foreach (var product in productsToDelete)
                {
                    byProducer.Remove(producer);
                    byPrice.Remove(product.Price, product);
                    byName.Remove(product.Name, product);
                    byProductNameProducer.Remove(string.Format("{0};{1}", product.Name, product.Producer), product);
                }

                return string.Format("{0} products deleted", productsToDelete.Length);
            }
            else
            {
                return NoProductsFound;
            }
        }

        private static string ExecuteFindProductsByPriceRange(decimal[] commandParams)
        {
            var products = byPrice.Range(commandParams[0], true, commandParams[1], true);

            if (products.Count != 0)
            {
                return string.Join(Environment.NewLine,
                    products.Values
                        .OrderBy(x => x.Name)
                        .ThenBy(x => x.Producer));
            }
            else
            {
                return NoProductsFound;
            }
        }

        private static string ExecuteFindProductsByProducer(string commandParam)
        {
            var products = byProducer[commandParam];
            if (products.Count != 0)
            {
                return string.Join(
                    Environment.NewLine,
                    products
                        .OrderBy(x => x.Name)
                        .ThenBy(x => x.Producer));

            }
            else
            {
                return NoProductsFound;
            }
        }

        private static string ExecuteFindProductsByName(string name)
        {
            var products = byName[name];
            if (products.Count != 0)
            {
                return string.Join(Environment.NewLine,
                    products
                        .OrderBy(x => x.Name)
                        .ThenBy(x => x.Producer));
            }
            else
            {
                return NoProductsFound;
            }
        }

        private static string ExecuteAddProduct(string[] lineParams)
        {
            var product = new Product(
                lineParams[0],
                decimal.Parse(lineParams[1]), lineParams[2]);

            byName.Add(product.Name, product);
            byProducer.Add(product.Producer, product);
            byPrice.Add(product.Price, product);
            byProductNameProducer.Add(string.Format("{0};{1}", product.Name, product.Producer), product);

            return ProductAdded;
        }
    }

    public class Product : IComparable
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Product;
            return string.Format("{0}{1}", this.Name, this.Producer)
                .CompareTo(string.Format("{0}{1}", other.Name, other.Producer));
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, (double)this.Price);
        }
    }
}
