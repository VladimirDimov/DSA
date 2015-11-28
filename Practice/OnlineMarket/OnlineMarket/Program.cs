namespace OnlineMarket
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
        static HashSet<string> productNames;
        static HashSet<string> types;
        static OrderedBag<Product> byPrice;
        static Dictionary<string, OrderedBag<Product>> byType;

        static void Main()
        {
            //var reader = new StreamReader("../../input/1.txt");
            //var writer = new StreamWriter("../../out/out.txt");
            //Console.SetIn(reader);
            //Console.SetOut(writer);

            productNames = new HashSet<string>();
            types = new HashSet<string>();
            byPrice = new OrderedBag<Product>();
            byType = new Dictionary<string, OrderedBag<Product>>();

            string line = null;
            do
            {
                line = Console.ReadLine();
                var lineWords = line
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = lineWords[0];

                if (lineWords[0] == "add")
                {
                    var isAdded = AddProduct(
                         new Product(lineWords[1],
                         decimal.Parse(lineWords[2]), lineWords[3]),
                         byPrice, byType);

                    if (isAdded)
                    {
                        Console.WriteLine("Ok: Product {0} added successfully", lineWords[1]);
                    }
                    else
                    {
                        Console.WriteLine("Error: Product {0} already exists", lineWords[1]);
                    }
                }
                else if (lineWords[0] == "filter")
                {
                    if (lineWords[2] == "type")
                    {
                        if (!types.Contains(lineWords[3]))
                        {
                            Console.WriteLine("Error: Type {0} does not exists", lineWords[3]);
                        }
                        else
                        {
                            Console.WriteLine("Ok: {0}", String.Join(", ", byType[lineWords[3]].Take(10)));
                        }
                    }
                    else if (lineWords[2] == "price")
                    {
                        decimal fromPrice = 0;
                        decimal toPrice = decimal.MaxValue;
                        if (lineWords[3] == "from")
                        {
                            fromPrice = decimal.Parse(lineWords[4]);

                            if (lineWords.Length > 5)
                            {
                                toPrice = decimal.Parse(lineWords[6]);
                            }
                        }
                        else
                        {
                            toPrice = decimal.Parse(lineWords[4]);
                        }

                        var productsInRange = byPrice
                            .Range(new Product("", fromPrice, ""), true, new Product("", toPrice, ""), true)
                            .Take(10);

                        PrintProducts(productsInRange);
                    }
                }
                else if (lineWords[0] == "end")
                {
                    break;
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Invalid command {0}", lineWords[0]));
                }
            } while (true);
        }

        static void PrintProducts(IEnumerable<Product> products)
        {
            Console.WriteLine("Ok: {0}", string.Join(", ", products));
        }

        private static bool AddProduct(
            Product product,
            OrderedBag<Product> byPrice,
            Dictionary<string, OrderedBag<Product>> byType)
        {
            if (productNames.Contains(product.Name))
            {
                return false;
            }

            productNames.Add(product.Name);
            types.Add(product.Type);

            byPrice.Add(product);

            if (byType.ContainsKey(product.Type))
            {
                byType[product.Type].Add(product);
            }
            else
            {
                byType.Add(product.Type, new OrderedBag<Product> { product });
            }

            return true;
        }
    }

    class Product : IComparable
    {
        public Product(string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Product;

            if (!this.Price.Equals(other.Price))
            {
                return this.Price.CompareTo(other.Price);
            }
            else
            {
                if (this.Name != other.Name)
                {
                    return this.Name.CompareTo(other.Name);
                }
                else
                {
                    return this.Type.CompareTo(other.Type);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price.ToString("G29"));
        }
    }
}
