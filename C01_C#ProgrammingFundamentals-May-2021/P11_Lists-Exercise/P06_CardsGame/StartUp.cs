namespace P06_CardsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string WINNER_MESSAGE = "{0} player wins! Sum: {1}";

        public static void Main()
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayer = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int count = firstPlayer.Count();

            while (true)
            {
                int index = 0;

                bool isInvalid = firstPlayer.Count == 0 || secondPlayer.Count == 0;
                if (isInvalid)
                {
                    break;
                }

                if (firstPlayer[index] > secondPlayer[index])
                {
                    AddCard(firstPlayer, secondPlayer);
                }
                else if (secondPlayer[index] > firstPlayer[index])
                {
                    AddCard(secondPlayer, firstPlayer);
                }
                else
                {
                    firstPlayer.RemoveAt(index);
                    secondPlayer.RemoveAt(index);
                }
            }

            int firstPlayerSum = firstPlayer.Sum();
            int secondPlayerSum = secondPlayer.Sum();

            string result = string.Format(WINNER_MESSAGE, "First", firstPlayerSum);

            if (secondPlayerSum > firstPlayerSum)
            {
                result = string.Format(WINNER_MESSAGE, "Second", secondPlayerSum);
            }

            Console.WriteLine(result);
        }

        private static void AddCard(List<int> thePlayerToWhomYouMustAddACard, List<int> thePlayerToWhomWeMustRemoveTheCard)
        {
            int index = 0;
            int firstCard = 0;
            int temp = 0;

            firstCard = thePlayerToWhomYouMustAddACard[index];
            temp = thePlayerToWhomWeMustRemoveTheCard[index];

            RemoveCard(thePlayerToWhomYouMustAddACard, index);
            thePlayerToWhomYouMustAddACard.Add(firstCard);
            thePlayerToWhomYouMustAddACard.Add(temp);
            RemoveCard(thePlayerToWhomWeMustRemoveTheCard, index);
        }

        private static void RemoveCard(List<int> player, int index)
        {
            player.RemoveAt(index);
        }
    }
}
