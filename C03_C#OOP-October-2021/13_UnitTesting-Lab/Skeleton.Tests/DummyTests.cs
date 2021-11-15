using System;

using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private int health;
    private int experience;

    [SetUp]
    public void SetUp()
    {
        this.health = 5;
        this.experience = 10;
        this.dummy = new Dummy(health, experience);
    }

    [Test]
    public void When_AttackedHeMustLoseHeal()
    {
        dummy.TakeAttack(1);

        Assert.That(dummy.Health, Is.EqualTo(this.health - 1));
    }

    [Test]
    public void When_DeadDummyWasAttck_ShowThrowExeption()
    {
        var dummy = new Dummy(0, experience);

        InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.TakeAttack(1);

        });

        Assert.That(ioe.Message, Is.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_Dead_ShowGiveXP()
    {
        var dummy = new Dummy(0, experience);
        var givenExpresionce = dummy.GiveExperience();

        Assert.That(givenExpresionce, Is.EqualTo(experience));
    }

    [Test]
    public void When_Alive_ShowNotGiveXP()
    {
        InvalidOperationException ioe = Assert.Throws<InvalidOperationException>(() =>
        {
            this.dummy.GiveExperience();

        });

        Assert.That(ioe.Message, Is.EqualTo("Target is not dead."));
    }
}
