namespace OrderedMultidictionary.Services
{
    using Helpers;
    using OrderedMultidictionary.Data;
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    class RandomArticlesGenerator
    {
        private RandomDataGenerator randomGenerator;
        HashSet<Guid> uniqueBarCodes = new HashSet<Guid>();

        public RandomArticlesGenerator()
        {
            this.randomGenerator = new RandomDataGenerator();
        }

        public Article GetRandomArticle()
        {
            var article = new Article
            {
                Barcode = GetUniqueBarcode(),
                Price = randomGenerator.GetRandomInt(1, 1000),
                Title = randomGenerator.GetRandomString(2, 20),
                Vendor = randomGenerator.GetRandomString(5, 10)
            };

            return article;
        }

        private Guid GetUniqueBarcode()
        {
            Guid barcode;

            do
            {
                barcode = Guid.NewGuid();
            } while (uniqueBarCodes.Contains(barcode));

            return barcode;
        }

        public OrderedMultiDictionary<decimal, Article> GetRandomArticlesCollection(int numberOfArticles)
        {
            var articles = new OrderedMultiDictionary<decimal, Article>(true);

            for (int i = 0; i < numberOfArticles; i++)
            {
                var articleToAdd = this.GetRandomArticle();
                articles.Add(articleToAdd.Price, articleToAdd);
            }

            return articles;
        }
    }
}
