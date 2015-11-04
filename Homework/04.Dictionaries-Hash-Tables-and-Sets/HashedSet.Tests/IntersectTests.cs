namespace HashedSet.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    class IntersectTests
    {
        [Test]
        public void IntersectExpectedToWorkProperly()
        {
            var firstSet = new HashedSet<string>();
            for (int i = 1; i <= 10; i++)
            {
                firstSet.Add("test" + i);
            }

            var secondSet = new HashedSet<string>();
            for (int i = 6; i <= 15; i++)
            {
                secondSet.Add("test" + i);
            }

            firstSet.Intersect(secondSet);

            Assert.AreEqual(5, firstSet.Count);

            for (int i = 6; i <= 10; i++)
            {
                Assert.IsTrue(firstSet.Find("test" + i));
            }
        }
    }
}
