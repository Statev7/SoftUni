using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {

        [Test]
        public void IfWeTryToCreateGymWithNullOrEmptyName_ShouldThrowExeption()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 3));
            Assert.Throws<ArgumentNullException>(() => new Gym(string.Empty, 3));
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 3));
        }

        [Test]
        public void IfWeTryToCreateGymWithNegativeCapacity_ShouldThrowExeption()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Olimpia", -1));
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.DoesNotThrow(() => new Gym("Olimpia", 0));
            Assert.DoesNotThrow(() => new Gym("Olimpia2", 1));
        }

        [Test]
        public void TestIfAddAthleteWorksCorrectly()
        {
            Gym gym = new Gym("Olimpia", 3);

            var athlete = new Athlete("Ina");

            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void AddAthleteWhenIsFull()
        {
            Gym gym = new Gym("MusculeArt", 1);

            var athlete = new Athlete("Ina");
            var secondAthlete = new Athlete("Goho");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(secondAthlete));
        }

        [Test]
        public void RemoveAthleteNotExist()
        {
            Gym gym = new Gym("Olimpia", 2);

            var athlete = new Athlete("Ina");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Gosho"));
        }

        [Test]
        public void AthleteInjuredTest()
        {
            var atlet = new Athlete("Ina");
            Assert.IsTrue(!atlet.IsInjured);
        }

        [Test]
        public void TestIfRemoveAthleteWorksCorrectly()
        {
            var gym = new Gym("Olimpia", 5);

            var athlete = new Athlete("Ina");
            var secondAthlete = new Athlete("Goho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(secondAthlete);

            int expectedResult = 2;
            int actualResult = gym.Count;

            Assert.DoesNotThrow(() => gym.RemoveAthlete("Ina"));
            Assert.AreEqual(expectedResult, actualResult);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Ina"));
        }

        [Test]
        public void InjureAthleteNotExist()
        {
            var gym = new Gym("Olimpia", 2);

            var athlete = new Athlete("Ina");
            var secondAthlete = new Athlete("Goho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(secondAthlete);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Ivan"));
        }
        [Test]
        public void TestIfInjureAthleteWorksCorrectly()
        {
            var gym = new Gym("Olimpia", 3);

            var athlete = new Athlete("Ina");
            var secondAthlete = new Athlete("Goho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(secondAthlete);
            gym.InjureAthlete("Goho");
            
            Assert.IsFalse(athlete.IsInjured);
            Assert.IsTrue(gym.InjureAthlete("Goho").IsInjured);
        }

        [Test]
        public void TestIfReportWorksCorrectly()
        {
            Gym gym = new Gym("Olimpia", 5);

            var athlete = new Athlete("Ina");
            var secondAthlete = new Athlete("Goho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(secondAthlete);

            Assert.AreEqual($"Active athletes at {gym.Name}: {athlete.FullName}, {secondAthlete.FullName}", gym.Report());
        }
    }
}
