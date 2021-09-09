﻿namespace Guild
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Guild guild = new Guild("Weekend Raiders", 20);
            Player player = new Player("Mark", "Rogue");
            Console.WriteLine(player);

            guild.AddPlayer(player);
            Console.WriteLine(guild.Count); //1
            Console.WriteLine(guild.RemovePlayer("Gosho")); //False

            Player firstPlayer = new Player("Pep", "Warrior");
            Player secondPlayer = new Player("Lizzy", "Priest");
            Player thirdPlayer = new Player("Mike", "Rogue");
            Player fourthPlayer = new Player("Marlin", "Mage");

            //Add description to player
            secondPlayer.Description = "Best healer EU";

            guild.AddPlayer(firstPlayer);
            guild.AddPlayer(secondPlayer);
            guild.AddPlayer(thirdPlayer);
            guild.AddPlayer(fourthPlayer);

            guild.PromotePlayer("Lizzy");

            Console.WriteLine(guild.RemovePlayer("Pep")); //True

            Player[] kickedPlayers = guild.KickPlayersByClass("Rogue");
            Console.WriteLine(string.Join(", ", kickedPlayers.Select(p => p.Name))); //Mark, Mike

            Console.WriteLine(guild.Report());
        }
    }
}
