namespace OrderedBag
{
    using System;
    using System.Collections;

    class Product : IComparable
    {
        public Product()
        {
        }

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public int CompareTo(object obj)
        {
            var otherProduct = obj as Product;
            return this.Price - otherProduct.Price;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}$", this.Name, this.Price);
        }
    }
}
