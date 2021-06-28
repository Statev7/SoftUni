namespace P03_Songs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P03_Songs.Models;

    public class StartUp
    {
        public static void Main()
        {
            int songsCount = int.Parse(Console.ReadLine());
            List<Song> allSongs = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                string[] arguments = Console.ReadLine().Split("_");

                string typeList = arguments[0];
                string name = arguments[1];
                string time = arguments[2];

                Song song = new Song(typeList, name, time);
                allSongs.Add(song);
            }

            string fillterCommand = Console.ReadLine();
            PrintResult(allSongs, fillterCommand);
        }

        private static void PrintResult(List<Song> allSongs, string fillterCommand)
        {
            if (fillterCommand != "all")
            {
                var filtredSongs = allSongs
                .Where(x => x.TypeList == fillterCommand)
                .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, filtredSongs));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, allSongs));
            }
        }
    }
}
