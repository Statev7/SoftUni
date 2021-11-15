namespace Tests
{
    using System;

    using FightingArena;

    using NUnit.Framework;

    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void CheckIfConstructorWorkCorrect()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void IfAddIsSuccesffuly_ShouldIncreseCount()
        {
            Warrior warrior = new Warrior("Goho", 30, 50);

            this.arena.Enroll(warrior);

            int expectedCount = 1;
            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void IfEnrollSameWarriors_ShouldThrowExeption()
        {
            Warrior warrior = new Warrior("Ivan", 30, 35);
            Warrior secondWarrior = new Warrior("Ivan", 30, 50);

            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(secondWarrior);
            });
        }

        [Test]
        public void IfAttackerNameIsNull_ShouldThrowExeption()
        {
            Arena arena = new Arena();

            string attackerName = null;
            Warrior deffender = new Warrior("Pesho", 30, 35);
            arena.Enroll(deffender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, deffender.Name);
            });
        }

        [Test]
        public void IfDefenderNameIsNull_ShouldThrowExeption()
        {
            Arena arena = new Arena();

            string defenderName = null;
            Warrior attacker = new Warrior("Pesho", 30, 35);
            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(defenderName, attacker.Name);
            });
        }

        [Test]
        public void TestingFightBetweenTwoWarriors()
        {
            Warrior attacker = new Warrior("Pesho", 20, 50);
            Warrior deffender = new Warrior("Goho", 10, 70);

            this.arena.Enroll(attacker);
            this.arena.Enroll(deffender);

            int expectedAttackerHp = attacker.HP - deffender.Damage;
            int expectedDefenderHp = deffender.HP - attacker.Damage;

            this.arena.Fight(attacker.Name, deffender.Name);

            int actualAttackerHp = attacker.HP;
            int actualDeffenderHp = deffender.HP;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
            Assert.AreEqual(expectedDefenderHp, actualDeffenderHp);
        }
    }
}
