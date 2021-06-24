namespace P02_MuOnline
{
    using System;

    public class StartUp
    {
        const int INITIAL_BLOOD_VALUE = 100;
        const int INITIAL_BITCOINT_VALUE = 0;
        const string HEALTH_MESSAGE = "You healed for {0} hp.";
        const string CURRENT_HEAL_MESSAGE = "Current health: {0} hp.";
        const string FOUND_BITCOINTS_MESSAGE = "You found {0} bitcoins.";
        const string KILLED_A_MONSTER_MESSAGE = "You slayed {0}.";
        const string DEAD_MESSAGE = "You died! Killed by {0}.";
        const string BEST_ROOM_MESSAGE = "Best room: {0}";
        const string WON_A_GAME_MESSAGE = "You've made it! {0}Bitcoins: {1} {2}Health: {3}";

        public static void Main()
        {
            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            int heal = INITIAL_BLOOD_VALUE;
            int totalBitcoints = INITIAL_BITCOINT_VALUE;
            int roomCount = 0;
            bool isDead = false;

            for (int index = 0; index < input.Length; index++)
            {
                var arguments = input[index].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = arguments[0];
                int amount = int.Parse(arguments[1].ToString());

                roomCount++;

                switch (command)
                {
                    case "potion": heal = AddHealth(heal, amount); break;
                    case "chest": totalBitcoints = AddBitcoint(totalBitcoints, amount); break;
                    default: heal = Kill(command, amount, heal, roomCount); break;
                }

                isDead = IsDead(heal);
                if (isDead)
                {
                    break;
                }
            }

            if (!isDead)
            {
                string wonAGameMessage =
                    string.Format(WON_A_GAME_MESSAGE, Environment.NewLine, totalBitcoints, Environment.NewLine, heal);
                Console.WriteLine(wonAGameMessage);
            }
        }

        private static int AddHealth(int heal, int addHeal)
        {
            string healthMessage = string.Empty;
            string currontMessage = string.Empty;

            if (heal == INITIAL_BLOOD_VALUE)
            {
                healthMessage = string.Format(HEALTH_MESSAGE, 0);
                currontMessage = string.Format(CURRENT_HEAL_MESSAGE, heal);
            }
            else
            {
                heal += addHeal;

                if (heal > INITIAL_BLOOD_VALUE)
                {
                    int surplusHeal = heal - INITIAL_BLOOD_VALUE;
                    int addedHeal = addHeal - surplusHeal;
                    heal = INITIAL_BLOOD_VALUE;

                    healthMessage = string.Format(HEALTH_MESSAGE, addedHeal);
                    currontMessage = string.Format(CURRENT_HEAL_MESSAGE, heal);
                }
                else
                {
                    healthMessage = string.Format(HEALTH_MESSAGE, addHeal);
                    currontMessage = string.Format(CURRENT_HEAL_MESSAGE, heal);
                }
            }

            Console.WriteLine(healthMessage);
            Console.WriteLine(currontMessage);

            return heal;
        }

        private static int AddBitcoint(int currontBitcountValue, int bitcointsCount)
        {
            string bitcointsMessage = string.Format(FOUND_BITCOINTS_MESSAGE, bitcointsCount);
            Console.WriteLine(bitcointsMessage);

            int sum = currontBitcountValue + bitcointsCount;
            return sum;
        }

        private static int Kill(string monsterType, int attackDamage, int heal, int roomCount)
        {
            bool isAlive = heal - attackDamage > 0;

            if (isAlive)
            {
                heal -= attackDamage;
                string killedAMonserMessage = string.Format(KILLED_A_MONSTER_MESSAGE, monsterType);
                Console.WriteLine(killedAMonserMessage);
            }
            else
            {
                string diedMessage = string.Format(DEAD_MESSAGE, monsterType);
                string bestRoomMessage = string.Format(BEST_ROOM_MESSAGE, roomCount);

                Console.WriteLine(diedMessage);
                Console.WriteLine(bestRoomMessage);
                return 0;
            }

            return heal;
        }

        private static bool IsDead(int heal)
        {
            bool isDead = heal <= 0;

            return isDead;
        }
    }
}
