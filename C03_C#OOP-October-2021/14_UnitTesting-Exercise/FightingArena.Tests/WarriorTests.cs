namespace Tests
{
    using System;

    using FightingArena;

    using NUnit.Framework;

    public class WarriorTests
    {
        private Warrior warrior;
        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void Setup()
        {
            this.name = "Pesho";
            this.damage = 20;
            this.hp = 40;
            this.warrior = new Warrior(this.name, this.damage, this.hp);
        }

        [Test]
        public void TestIfConstructorWorkCorrect()
        {
            string expectedName = "Pesho";
            int expectedDamage = 20;
            int expectedHp = 40;

            string actualName = this.warrior.Name;
            int actualDamage = this.warrior.Damage;
            int actualHp = this.warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHp, actualHp);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void IfNameIsNullOrEmpty_ShouldThrowExeption(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, this.damage, this.hp);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void IfDamageIsZeroOrNegative_ShouldThrowExeption(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(this.name, damage, this.hp);
            });
        }

        [Test]
        public void IfHpIsNegative_ShouldThrowExeption()
        {
            int hp = -1;
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(this.name, this.damage, hp);
            });
        }

        [Test]
        [TestCase(30)]
        [TestCase(25)]
        public void IfHpIsLessOrEqualThatNeededToAttack_ShouldThrowExeption(int hp)
        {
            Warrior warrior = new Warrior(this.name, this.damage, hp);
            Warrior defendWarrior = new Warrior("Goho", this.damage, this.hp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(defendWarrior);
            });
        }

        [Test]
        [TestCase(30)]
        [TestCase(25)]
        public void IfTheWarriorWeAreAttckingHasLessOrEqualThanTheMinimumHp_ShouldThrowExeption(int hp)
        {
            Warrior defendWarrior = new Warrior("Pesho", this.damage, hp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(defendWarrior);
            });
        }

        [Test]
        public void IfTheWWarriorWeAttackHasMoreDamage_ShouldThrowExeption()
        {
            Warrior aWarrior = new Warrior("Goho", 20, 35);
            Warrior dWarrior = new Warrior("Pesho", 50, 40);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aWarrior.Attack(dWarrior);
            });
        }

        [Test]
        public void IfAttackIsSuccessfully_ShouldReduceHp()
        {
            Warrior aWarior = new Warrior("Pesho", 30, 50);
            Warrior dWarrior = new Warrior("Goho", 20, 35);

            aWarior.Attack(dWarrior);

            //50 - 30
            int expectedAWarriorHp = 30;
            int actualAWarriorHp = aWarior.HP;

            int expectedDWarriorHp = 5;
            int actualDWarriorHp = dWarrior.HP;

            Assert.AreEqual(expectedAWarriorHp, actualAWarriorHp);
            Assert.AreEqual(expectedDWarriorHp, actualDWarriorHp);
        }

        [Test]
        public void IfThereIsDamageIsMoreThatTheOpponentHp_ShouldSetOpponentHpToZero()
        {
            Warrior aWarrior = new Warrior("Pesho", 50, 35);
            Warrior dWarrior = new Warrior("Goho", 10, 35);

            aWarrior.Attack(dWarrior);

            int expectedHp = 0;
            int actualHp = dWarrior.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }
    }
}