namespace P07_SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string PARTY_COMMAND = "PARTY";
        const string COMMAND_TO_END_PARTY = "END";

        public static void Main()
        {
            var regularGuest = new HashSet<string>();
            var vipGuest = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != PARTY_COMMAND)
            {
                bool isVipGuests = char.IsDigit(input[0]) && input.Length == 8;
                bool isRegularGuest = input.Length == 8;
                if (isVipGuests)
                {
                    vipGuest.Add(input);
                }
                else if (isRegularGuest)
                {
                    regularGuest.Add(input);
                }

                input = Console.ReadLine();
            }

            string guestsWhoComeToParty = Console.ReadLine();
            while (guestsWhoComeToParty != COMMAND_TO_END_PARTY)
            {
                bool isVip = vipGuest.Contains(guestsWhoComeToParty);
                bool isRegular = regularGuest.Contains(guestsWhoComeToParty);
                if (isVip)
                {
                    vipGuest.Remove(guestsWhoComeToParty);
                }
                else if (isRegular)
                {
                    regularGuest.Remove(guestsWhoComeToParty);
                }

                guestsWhoComeToParty = Console.ReadLine();
            }

            PrintResult(regularGuest, vipGuest);
        }

        private static void PrintResult(HashSet<string> regularGuest, HashSet<string> vipGuest)
        {
            Console.WriteLine(vipGuest.Count + regularGuest.Count);
            foreach (var guest in vipGuest)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuest)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
