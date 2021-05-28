namespace P03_GamingStore
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string gameName = Console.ReadLine();

            double totalSpent = 0;
            bool isOutOfMoney = false;

            while (gameName != "Game Time")
            {
                bool isValid = CheckAreGameValid(gameName);

                if (isValid)
                {
                    double price = GamePrice(gameName);

                    if (currentBalance < price)
                    {
                        Console.WriteLine("Too Expensive");
                    }
                    else if(currentBalance >= price)
                    {
                        currentBalance -= price;
                        totalSpent += price;

                        Console.WriteLine($"Bought {gameName}");

                        if (currentBalance == 0)
                        {
                            isOutOfMoney = true;
                            Console.WriteLine("Out of money!");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                gameName = Console.ReadLine();
            }

            if (!isOutOfMoney)
            {
                PrintResult(totalSpent, currentBalance);
            }
        }

        private static bool CheckAreGameValid(string game)
        {
            bool isValid = game == "OutFall 4" || 
                game == "CS: OG" || 
                game == "Zplinter Zell" || 
                game == "Honored 2" || 
                game == "RoverWatch" || 
                game == "RoverWatch Origins Edition";

            return isValid;
        }

        private static double GamePrice(string game)
        {
            const double OUT_FALL_4_PRICE = 39.99;
            const double CS_OG_PRICE = 15.99;
            const double ZPLINTER_ZELL_PRICE = 19.99;
            const double HONORED_2_PRICE = 59.99;
            const double ROVERWATCH_PRICE = 29.99;
            const double ROVERWATCH_ORIGINS_EDITION_PRICE = 39.99;

            double price = 0;

            switch (game)
            {
                case "OutFall 4": price = OUT_FALL_4_PRICE; break;
                case "CS: OG": price = CS_OG_PRICE; break;
                case "Zplinter Zell": price = ZPLINTER_ZELL_PRICE; break;
                case "Honored 2": price = HONORED_2_PRICE; break;
                case "RoverWatch": price = ROVERWATCH_PRICE; break;
                case "RoverWatch Origins Edition": price = ROVERWATCH_ORIGINS_EDITION_PRICE; break;
            }

            return price;
        }

        private static void PrintResult(double totalSpent, double remaining)
        {
            string result = $"Total spent: ${totalSpent:F2}. Remaining: ${remaining:F2}";

            Console.WriteLine(result);
        }
    }
}
