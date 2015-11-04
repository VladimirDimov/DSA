namespace HashedSet.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class FindTests
    {
        [Test]
        public void ShouldReturnTrueWhenTryingToFindAvailableElement()
        {
            var hashedSet = new HashedSet<string>();

            for (int i = 0; i < 10; i++)
            {
                hashedSet.Add("test" + i);
            }

            for (int i = 0; i < 10; i++)
            {
                var expectedTrue = hashedSet.Find("test" + i);

                Assert.IsTrue(expectedTrue);
            }
        }

        [Test]
        public void ShouldReturnFalseWhenTryingToFindUnavailableElement()
        {
            var hashedSet = new HashedSet<string>();

            for (int i = 0; i < 10; i++)
            {
                hashedSet.Add("test" + i);
            }

            for (int i = 0; i < 10; i++)
            {
                var expectedFalse = hashedSet.Find("false" + i);

                Assert.IsFalse(expectedFalse);
            }
        }
    }
}
