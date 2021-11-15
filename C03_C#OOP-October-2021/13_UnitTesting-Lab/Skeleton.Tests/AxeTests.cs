using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{

    [Test]
    public void When_AxeAttacks_ItMustLoseDurability()
    {
        var axe = new Axe(5, 10);
        var dummy = new Dummy(10, 10);

        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
    }

    [Test]
    public void When_WeaponIsBroken_ShowThrowExeption()
    {
        var axe = new Axe(5, -1);
        var dummy = new Dummy(10, 10);

        InvalidOperationException ipe = Assert.Throws<InvalidOperationException>(() =>
        {
            axe.Attack(dummy);
        });

        Assert.That(ipe.Message, Is.EqualTo("Axe is broken."));
    }
}