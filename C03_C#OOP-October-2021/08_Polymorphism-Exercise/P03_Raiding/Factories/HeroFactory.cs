namespace Rading.Factories
{
    using System;

    using Rading.Models;
    using Rading.Models.Fighters;
    using Rading.Models.Healers;

    public class HeroFactory
    {
        private const string INVALID_HERO_ERROR_MESSAGE = "Invalid hero!";

        public BaseHero Create(string heroType, string heroName)
        {
            BaseHero hero = null;

            switch (heroType)
            {
                case "Druid": hero = new Druid(heroName); break;
                case "Paladin": hero = new Paladin(heroName); break;
                case "Rogue": hero = new Rogue(heroName); break;
                case "Warrior": hero = new Warrior(heroName); break;
            }

            if (hero == null)
            {
                throw new ArgumentException(INVALID_HERO_ERROR_MESSAGE);
            }

            return hero;
        }
    }
}
