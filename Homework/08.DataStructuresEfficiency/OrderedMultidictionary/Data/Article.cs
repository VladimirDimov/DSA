namespace OrderedMultidictionary.Data
{
    using System;
    using System.Text;

    class Article : IComparable
    {
        public string Title { get; set; }

        public Guid Barcode { get; set; }

        public decimal Price { get; set; }

        public string Vendor { get; set; }

        public int CompareTo(object obj)
        {
            var otherArticle = obj as Article;

            if (otherArticle == null)
            {
                throw new ArgumentException("Invalid article!");
            }

            return this.Price.CompareTo(otherArticle.Price);
        }

        public override string ToString()
        {
            return string.Format("Title: {0,-20}, Price: {1, 4}", this.Title, this.Price);
        }
    }
}
