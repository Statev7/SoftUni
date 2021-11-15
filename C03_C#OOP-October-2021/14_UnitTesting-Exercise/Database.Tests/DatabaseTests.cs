using System;

using Database;

using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(new int[] { 1 });
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] {1,2,3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void TestIfConstructorCapacityWorksCorrectly(int[] date)
        {
            Database.Database database = new Database.Database(date);

            int expectedCount = date.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorWithBiggestCapacityShouldThrowExeption()
        {
            int[] date = new int[17];

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database.Database database = new Database.Database(date);
            });
        }

        [Test]
        public void TheAddtionMustIncreaseCount()
        {
            int expectedCount = 2;

            this.database.Add(2);

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingShouldThrowExeptionIfCapacityIsFull()
        {
            for (int i = 1; i < 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(1);
            });
        }

        [Test]
        public void RemoveShouldDecreasesCount()
        {
            int expectedCount = 0;

            this.database.Remove();

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExeptionIfDateIsEmpty()
        {
            Database.Database database = new Database.Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void TestIfFetchReturnElementsAsArray()
        {
            int[] exprectedDate = new int[] { 1, 2, 3 };

            Database.Database database = new Database.Database(exprectedDate);

            int[] actualDate = database.Fetch();

            CollectionAssert.AreEqual(exprectedDate, actualDate);
        }

    }
}