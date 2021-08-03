namespace P11_KeyRevolver
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string PING_MESSAGE = "Ping!";
        const string BANG_MESSAGE = "Bang!";
        const string RELOADING_MESSAGE = "Reloading!";
        const string BULLETS_LEFT_MESSAGE = "{0} bullets left. Earned ${1}";
        const string CANT_UNLOCK_MESSAGE = "Couldn't get through. Locks left: {0}";

        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int bulletSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] locksInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);
            int bulletsCount = 0;
            int bulletCountForReloading = 0;
            bool isBreak = false;

            while (locks.Count > 0)
            {
                if (bullets.Count == 0)
                {
                    isBreak = true;
                    break;
                }
                Remove(bullets, locks);

                bulletCountForReloading++;
                bulletsCount++;

                bool canRealod = bulletCountForReloading == bulletSize && bullets.Count > 0;
                if (canRealod)
                {
                    bulletCountForReloading = 0;
                    Console.WriteLine(RELOADING_MESSAGE);
                }
            }

            PrintResult(bulletPrice, intelligence, bullets, locks, bulletsCount, isBreak);
        }

        private static void Remove(Stack<int> bullets, Queue<int> locks)
        {
            bool canUnlock = bullets.Peek() <= locks.Peek();
            if (canUnlock)
            {
                bullets.Pop();
                locks.Dequeue();
                Console.WriteLine(BANG_MESSAGE);
            }
            else
            {
                bullets.Pop();
                Console.WriteLine(PING_MESSAGE);
            }
        }

        private static void PrintResult(int bulletPrice, int intelligence, Stack<int> bullets, Queue<int> locks, int bulletsCount, bool isBreak)
        {
            if (isBreak)
            {
                Console.WriteLine(CANT_UNLOCK_MESSAGE, locks.Count);
            }
            else
            {
                int price = intelligence - (bulletsCount * bulletPrice);
                Console.WriteLine(string.Format(BULLETS_LEFT_MESSAGE, bullets.Count, price));
            }
        }
    }
}
