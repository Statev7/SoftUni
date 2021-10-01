namespace Rading.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Rading.Core.Contracts;
    using Rading.Factories;
    using Rading.IO.Contracts;
    using Rading.Models;

    public class Engine : IEngine
    {
        private const string VICTORY_MESSAGE = "Victory!";
        private const string LOSE_MESSAGE = "Defeat...";

        private readonly ICollection<BaseHero> heroes;
        private IReader reader;
        private IWriter writer;

        private Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public Engine(IReader reader, IWriter writer)
           : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.AddHero();
            this.UseAbilityes();
            this.PrintResult();
        }

        private void AddHero()
        {
            var heroursCount = int.Parse(reader.ReadLine());
            while (this.heroes.Count != heroursCount)
            {
                var heroName = reader.ReadLine();
                var heroType = reader.ReadLine();

                try
                {
                    var heroFactory = new HeroFactory();
                    var hero = heroFactory.Create(heroType, heroName);
                    this.heroes.Add(hero);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private void UseAbilityes()
        {
            foreach (var hero in this.heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }
        }

        private void PrintResult()
        {
            var bossHeal = int.Parse(reader.ReadLine());
            var herosPower = this.heroes.Sum(x => x.Power);

            var result = bossHeal > herosPower ? LOSE_MESSAGE : VICTORY_MESSAGE;
            Console.WriteLine(result);
        }
    }
}
