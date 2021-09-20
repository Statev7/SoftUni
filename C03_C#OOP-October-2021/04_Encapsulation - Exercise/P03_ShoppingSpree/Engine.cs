namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string COMMAND_TO_END_READ_ARGUMENTS = "END";

        private readonly List<Person> people;
        private readonly List<Product> products;

        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {
            try
            {
                string[] peopleArg = Console.ReadLine()
                .Split(new[] { "=", ";" }, StringSplitOptions.None);

                string[] productArg = Console.ReadLine()
                    .Split(new[] { "=", ";" }, StringSplitOptions.None);

                this.CreatePerson(peopleArg);
                this.CreateProduct(productArg);
                this.ExecuteCommands();
                this.PrintOutput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreatePerson(string[] peopleArg)
        {
            for (int i = 0; i < peopleArg.Length; i += 2)
            {
                string name = peopleArg[i];
                double money = double.Parse(peopleArg[i + 1]);

                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }

        private void CreateProduct(string[] productArg)
        {
            for (int i = 0; i < productArg.Length; i += 2)
            {
                string name = productArg[i];
                double price = double.Parse(productArg[i + 1]);

                Product product = new Product(name, price);
                products.Add(product);
            }
        }

        private void ExecuteCommands()
        {
            string commands = Console.ReadLine();
            while (commands != COMMAND_TO_END_READ_ARGUMENTS)
            {
                string[] splited = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = splited[0];
                string productName = splited[1];

                var person = this.people
                    .Where(x => x.Name == personName)
                    .FirstOrDefault();

                var product = this.products
                    .Where(x => x.Name == productName)
                    .FirstOrDefault();

                if (person != null && product != null)
                {
                    Console.WriteLine(person.BuyProduct(product));
                }

                commands = Console.ReadLine();
            }
        }

        private void PrintOutput()
        {
            foreach (var person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
            }
        }
    }
}
