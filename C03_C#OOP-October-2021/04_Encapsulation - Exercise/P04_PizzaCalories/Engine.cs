namespace PizzaCalories
{
    using System;
    using System.Linq;

    public class Engine
    {
        private const string COMMAND_TO_END_READ_INPUT = "END";

        public void Run()
        {
            try
            {
                string[] pizzaArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.None)
                    .Skip(1)
                    .ToArray();

                string[] doughArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToArray();

                Dough dough = CreateDough(doughArg);
                Pizza pizza = CreatePizza(pizzaArg, dough);
                ExecuteCommands(pizza);
                PrintOutput(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Dough CreateDough(string[] doughArg)
        {
            string doughType = doughArg[0];
            string doughTechnique = doughArg[1];
            double weight = double.Parse(doughArg[2]);

            Dough dough = new Dough(doughType, doughTechnique, weight);
            return dough;
        }

        private static Pizza CreatePizza(string[] pizzaArg, Dough dough)
        {
            string pizzaName = pizzaArg[0];
            Pizza pizza = new Pizza(pizzaName, dough);
            return pizza;
        }

        private static Topping CreateTopping(string[] splited)
        {
            string toppingType = splited[0];
            double toppingWeight = double.Parse(splited[1]);

            Topping topping = new Topping(toppingType, toppingWeight);
            return topping;
        }

        private static void ExecuteCommands(Pizza pizza)
        {
            string commands = Console.ReadLine();
            while (commands != COMMAND_TO_END_READ_INPUT)
            {
                string[] splited = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToArray();

                Topping topping = CreateTopping(splited);
                pizza.AddTopping(topping);

                commands = Console.ReadLine();
            }
        }

        private static void PrintOutput(Pizza pizza)
        {
            Console.WriteLine(pizza);
        }
    }
}
