using System;
using NUnit.Framework;

namespace HashTable.Tests
{
    [TestFixture]
    public class AddTests
    {
        [Test]
        public void ShouldIncreaseCounterWithEachAddedElement()
        {
            var hashtable = new HashTable<int, string>();

            int numberOfAddedElements = 5;
            for (int i = 0; i < numberOfAddedElements; i++)
            {
                hashtable.Add(i, "test");
                Assert.AreEqual(i + 1, hashtable.Count);
            }
        }
    }
}
