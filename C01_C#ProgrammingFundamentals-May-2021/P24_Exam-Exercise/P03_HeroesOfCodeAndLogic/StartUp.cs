namespace P03_HeroesOfCodeAndLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        const int MAXIMUM_MP = 200;
        const int MAXIMUM_HEAL = 100;

        const string COMMAND_TO_STOP = "End";
        const string SUCCESSFULL_CAST_MESSAGE = "{0} has successfully cast {1} and now has {2} MP!";
        const string NOT_HAVE_ENOUGH_MP_ERROR_MESSAGE = "{0} does not have enough MP to cast {1}!";
        const string TAKE_A_DAMAGE_MESSAGE = "{0} was hit for {1} HP by {2} and now has {3} HP left!";
        const string HERO_DEAD_MESSAGE = "{0} has been killed by {1}!";
        const string RECHARGE_MESSAGE = "{0} recharged for {1} MP!";
        const string HEAL_MESSAGE = "{0} healed for {1} HP!";

        public static void Main()
        {
            List<Hero> allHeroes = new List<Hero>();
            AddHero(allHeroes);
            ExecuteCommands(allHeroes);
        }

        private static void AddHero(List<Hero> allHeroes)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = arguments[0];
                int hp = int.Parse(arguments[1]);
                int mp = int.Parse(arguments[2]);

                Hero hero = new Hero(name, hp, mp);
                allHeroes.Add(hero);
            }
        }

        private static void ExecuteCommands(List<Hero> allHeroes)
        {
            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arguments[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintResult(allHeroes);
                    break;
                }

                string command = arguments[0];
                string heroName = arguments[1];
                int amount = 0;

                switch (command)
                {
                    case "CastSpell":
                        int mp = int.Parse(arguments[2]);
                        string spellName = arguments[3];
                        CastSpell(allHeroes, heroName, mp, spellName);
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(arguments[2]);
                        string attacker = arguments[3];
                        TakeDamage(allHeroes, heroName, damage, attacker);
                        break;
                    case "Recharge":
                        amount = int.Parse(arguments[2]);
                        Recharge(allHeroes, heroName, amount);
                        break;
                    case "Heal":
                        amount = int.Parse(arguments[2]);
                        Heal(allHeroes, heroName, amount);
                        break;
                }
            }
        }

        private static void CastSpell(List<Hero> allHeroes, string heroName, int needMP, string spellName)
        {
            Hero hero = FindHero(allHeroes, heroName);

            bool isThereANecessaryMP = hero.MP >= needMP;
            if (isThereANecessaryMP)
            {
                hero.MP -= needMP;
                PrintMessage(string.Format(SUCCESSFULL_CAST_MESSAGE, heroName, spellName, hero.MP));
            }
            else
            {
                PrintMessage(string.Format(NOT_HAVE_ENOUGH_MP_ERROR_MESSAGE, heroName, spellName));
            }
        }

        private static void TakeDamage(List<Hero> allHeroes, string heroName, int damage, string attacker)
        {
            Hero hero = FindHero(allHeroes, heroName);

            bool isHeroAlive = hero.HP - damage > 0;
            if (isHeroAlive)
            {
                hero.HP -= damage;
                PrintMessage(string.Format(TAKE_A_DAMAGE_MESSAGE, heroName, damage, attacker, hero.HP));
            }
            else
            {
                allHeroes.Remove(hero);
                PrintMessage(string.Format(HERO_DEAD_MESSAGE, heroName, attacker));
            }
        }

        private static void Recharge(List<Hero> allHeroes, string heroName, int amount)
        {
            Hero hero = FindHero(allHeroes, heroName);

            bool isItMoreThatTheMaximumMP = hero.MP + amount > MAXIMUM_MP;
            if (isItMoreThatTheMaximumMP)
            {
                int mp = MAXIMUM_MP - hero.MP;
                hero.MP = MAXIMUM_MP;
                PrintMessage(string.Format(RECHARGE_MESSAGE, heroName, mp));
            }
            else
            {
                hero.MP += amount;
                PrintMessage(string.Format(RECHARGE_MESSAGE, heroName, amount));
            }
        }

        private static void Heal(List<Hero> allHeroes, string heroName, int amount)
        {
            Hero hero = FindHero(allHeroes, heroName);

            bool isItMoreThatTheMaximumHeal = hero.HP + amount > MAXIMUM_HEAL;
            if (isItMoreThatTheMaximumHeal)
            {
                int heal = MAXIMUM_HEAL - hero.HP;
                hero.HP = MAXIMUM_HEAL;
                PrintMessage(string.Format(HEAL_MESSAGE, heroName, heal));
            }
            else
            {
                hero.HP += amount;
                PrintMessage(string.Format(HEAL_MESSAGE, heroName, amount));
            }
        }

        private static Hero FindHero(List<Hero> allHeros, string heroName)
        {
            return allHeros
                          .Where(x => x.Name == heroName)
                          .SingleOrDefault();
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void PrintResult(List<Hero> allheroes)
        {
            allheroes = allheroes
                .OrderByDescending(x => x.HP)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var hero in allheroes)
            {
                Console.WriteLine(hero);
            }
        }
    }

    public class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            this.Name = name;
            this.HP = hp;
            this.MP = mp;
        }

        public string Name { get; private set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"{this.Name}");
            str.AppendLine($"  HP: {this.HP}");
            str.AppendLine($"  MP: {this.MP}");

            return str.ToString().TrimEnd();
        }
    }
}
