using NUnit.Framework;
using System;

namespace HashTable.Tests
{
    [TestFixture]
    public class FindTests
    {
        [Test]
        public void ShouldReturnTheRightValueWhenTheRequestedKeyIsAvailable()
        {
            var hashtable = new HashTable<int, string>();

            int numberOfAddedElements = 5;
            for (int i = 0; i < numberOfAddedElements; i++)
            {
                hashtable.Add(i, "test" + i);
            }

            var foundValue = hashtable.Find(3);

            Assert.AreEqual("test3", foundValue);
        }

        [Test]
        [ExpectedException]
        public void ShouldThrowWhenRequesttedKeyIsNotAvailable()
        {
            var hashtable = new HashTable<int, string>();

            int numberOfAddedElements = 5;
            for (int i = 0; i < numberOfAddedElements; i++)
            {
                hashtable.Add(i, "test" + i);
            }

            var foundValue = hashtable.Find(10);
        }
    }
}
