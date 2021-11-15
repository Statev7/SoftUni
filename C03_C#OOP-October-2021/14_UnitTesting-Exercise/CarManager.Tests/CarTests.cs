using System;

using CarManager;

using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelAmount;
        private double fuelCapacity;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.make = "Audi";
            this.model = "A6";
            this.fuelConsumption = 5;
            this.fuelAmount = 0;
            this.fuelCapacity = 30;
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void TestIfConstuctorWorkCorrect()
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            string expectedMake = this.make;
            string expectedModel = this.model;
            double expectedFuelConsumption = this.fuelConsumption;
            double expectedFuelCapacity = this.fuelCapacity;
            double expectedFuelAmount = this.fuelAmount;

            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void IfTheMarkIsNullOrEmpty_ShouldThrowExeption(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, this.model, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void IfTheModelIsNullOrEmpty_ShouldThrowExeption(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, model, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void IfTheConsumtionIsZeroOrNegative_ShouldThrowExeption(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, this.model, fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void IfTheFuelCapacityIsZeroOrNegative_ShouldThrowExeption(int fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(this.make, this.model, this.fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void IfTheRefuelSucessfully_MustIncreaseFuelAmount()
        {
            this.car.Refuel(5);

            double expectedFuelAmount = 5;
            double actualFuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void IfTheFuelTorefuelIsZeroOrNegative_ShouldThrowExeption(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(fuelToRefuel);
            });
        }

        [Test]
        public void IfFuelToRefuelIsMoreThatTheCapacity_ShouldSetTheValueOfTheAmoutAsThatOfTheCapacity()
        {
            this.car.Refuel(35);

            double expectedFuelAmount = 30;
            double actualFuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void IfTheDriveSuccesfulyy_MustReduceFuelAmount()
        {
            this.car.Refuel(20);
            this.car.Drive(100);

            double expectedFuelAmount = 15;
            double actualFuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void IfDontHaveFuelToDrive_ShouldThrowExeption()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(10);
            });
        }
    }
}