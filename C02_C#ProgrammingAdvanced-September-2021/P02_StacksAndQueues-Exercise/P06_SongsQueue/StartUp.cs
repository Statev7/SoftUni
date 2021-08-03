namespace P06_SongsQueue
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string SONG_ALREADY_IN_ERROR_MESSAGE = "{0} is already contained!";
        const string RESULT_MESSAGE = "No more songs!";

        public static void Main()
        {
            var songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> allSongs = new Queue<string>(songs);

            while (allSongs.Count > 0)
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    allSongs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string song = command.Substring(4);
                    AddSong(allSongs, song);
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", allSongs.ToArray()));
                }
            }

            Console.WriteLine(RESULT_MESSAGE);
        }

        private static void AddSong(Queue<string> allSongs, string song)
        {
            bool isAlredyIn = allSongs.Contains(song);
            if (isAlredyIn)
            {
                Console.WriteLine(string.Format(SONG_ALREADY_IN_ERROR_MESSAGE, song));
            }
            else
            {
                allSongs.Enqueue(song);
            }
        }
    }
}
