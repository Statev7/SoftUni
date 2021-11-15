using System;

using ExtendedDatabase;

using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void TestIfConstructorCapacityWorksCorrectly()
        {
            Person person = new Person(1, "Pesho");
            Person secondPerson = new Person(2, "Ivan");

            Person[] people = new Person[] { person, secondPerson };

            int expectedCount = 2;

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            int actualCount = extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorWithBiggestCapacityShouldThrowExeption()
        {
            Person[] people = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                Person person = new Person(i, $"Pesho{i}");
                people[i] = person;
            }

            Assert.Throws<ArgumentException>(() =>
            {
                ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            });
        }

        [Test]
        public void IfTheAddtionSucessfullyMustIncreaseCount()
        {
            int expectedCount = 1;

            Person person = new Person(1, "Pesho");
            this.extendedDatabase.Add(person);

            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingShouldThrowExeptionIfCapacityIsFull()
        {
            for (int i = 0; i < 16; i++)
            {
                Person person = new Person(i, $"Pesho{i}");
                this.extendedDatabase.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = new Person(17, "Pesho17");
                this.extendedDatabase.Add(person);
            });
        }

        [Test]
        public void IfAddAPersonWithANameThatAlreadyExistsShouldThrowExeption()
        {
            Person person = new Person(1, "Pesho");
            Person secondPerson = new Person(2, "Pesho");

            this.extendedDatabase.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(secondPerson);
            });
        }

        [Test]
        public void IfAddAPersonWithAIdThatAlreadyExistsShouldThrowExeption()
        {
            Person person = new Person(1, "Pesho");
            Person secondPerson = new Person(1, "Pesho1");

            this.extendedDatabase.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(secondPerson);
            });
        }

        [Test]
        public void RemoveShouldDecreasesCount()
        {
            int expectedCount = 0;

            Person person = new Person(1, "Pesho");
            this.extendedDatabase.Add(person);
            this.extendedDatabase.Remove();

            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShouldThrowExeptionIfDateIsEmpty()
        {
            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Remove();
            });
        }

        [Test]
        public void FindByNameShouldReturdPerson()
        {
            Person expectedPerson = new Person(1, "Ina");
            this.extendedDatabase.Add(expectedPerson);

            Person actualPerson = this.extendedDatabase.FindByUsername("Ina");

            string expectedName = expectedPerson.UserName;
            string actualName = actualPerson.UserName;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void IfTryToFindNullOrEmptyNameShouldThrowExeption(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.extendedDatabase.FindByUsername(name);
            });
        }

        [Test]
        public void IfTryToFindPersonByNameThatDoesNotExistShouldThrowExeption()
        {
            Person person = new Person(1, "Ivan");
            string personNameToFind = "Ivan2";

            this.extendedDatabase.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindByUsername(personNameToFind);
            });
        }

        [Test]
        public void FindByIdShouldReturdPerson()
        {
            Person expectedPerson = new Person(1, "Goho");
            this.extendedDatabase.Add(expectedPerson);

            Person actualPerson = this.extendedDatabase.FindById(1);

            int expectedId = (int)expectedPerson.Id;
            int actualId = (int)actualPerson.Id;

            Assert.AreEqual(expectedId, actualId);

        }

        [Test]
        public void IfTryToFindPersonByNegativeIdShoulThrowExeption()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.extendedDatabase.FindById(-1);
            });
        }

        [Test]
        public void IfTryToFindPersonByIdThatDoesNotExistShouldThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.FindById(1);
            });
        }
    }
}