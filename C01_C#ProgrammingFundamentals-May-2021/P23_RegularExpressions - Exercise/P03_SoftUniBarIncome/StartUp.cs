namespace P03_SoftUniBarIncome
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end of shift";
        const string PATTERN = @"%(?<name>\b[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*[|](?<count>\d+)[|][^|$%.]*?(?<price>\d+[.]?\d+)[$]";

        public static void Main()
        {
            var validPeople = new Dictionary<string, Person>();

            while (true)
            {
                string input = Console.ReadLine();

                bool isStopCommand = COMMAND_TO_STOP == input;
                if (isStopCommand)
                {
                    PrintResult(validPeople);
                    break;
                }

                Regex regex = new Regex(PATTERN);
                var peopleInformation = regex.Matches(input);

                foreach (Match people in peopleInformation)
                {
                    string name = people.Groups["name"].Value;
                    string product = people.Groups["product"].Value;
                    int count = int.Parse(people.Groups["count"].Value.ToString());
                    decimal price = decimal.Parse(people.Groups["price"].Value.ToString());
                    decimal sum = count * price;

                    Person person = new Person(product, sum);
                    validPeople.Add(name, person);
                }
            }
        }

        private static void PrintResult(Dictionary<string, Person> validPeople)
        {
            decimal totalSum = 0;

            foreach (var person in validPeople)
            {
                Console.WriteLine($"{person.Key}: {person.Value.ProductName} - {person.Value.Price:F2}");
                totalSum += person.Value.Price;
            }

            Console.WriteLine($"Total income: {totalSum:F2}");
        }
    }

    public class Person
    {
        public Person(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; private set; }

        public decimal Price { get; private set; }
    }
}
