namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BorderControl.Models;
    using BorderControl.Models.Interfaces;

    public class Engine
    {
        private const string COMMAND_TO_END_READ_ARGUMENTSS = "End";

        private readonly List<ICreatures> creatures;

        public Engine()
        {
            this.creatures = new List<ICreatures>();
        }

        public void Run()
        {
            var input = Console.ReadLine();
            while (input != COMMAND_TO_END_READ_ARGUMENTSS)
            {
                var splited = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (splited.Length == 3)
                {
                    this.AddHuman(splited);
                }
                else if(splited.Length == 2)
                {
                    this.AddRobot(splited);
                }

                input = Console.ReadLine();
            }

            string filter = Console.ReadLine();
            this.PrintOutput(filter);
        }

        private void AddRobot(string[] splited)
        {
            var model = splited[0];
            var id = splited[1];
            var robot = new Robot(model, id);

            this.creatures.Add(robot);
        }

        private void AddHuman(string[] splited)
        {
            var name = splited[0];
            var age = int.Parse(splited[1]);
            var id = splited[2];
            var human = new Human(name, age, id);

            this.creatures.Add(human);
        }

        private void PrintOutput(string filter)
        {
            foreach (var creature in this.creatures
                .Where(x => x.Id.EndsWith(filter)))
            {
                Console.WriteLine(creature.Id);
            }
        }
    }
}
