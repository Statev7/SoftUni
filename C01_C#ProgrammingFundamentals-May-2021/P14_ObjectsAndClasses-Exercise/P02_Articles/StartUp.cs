namespace P02_Articles
{
    using System;

    using P02_Articles.Models;

    public class StartUp
    {
        public static void Main()
        {
            string[] argumens = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = argumens[0];
            string content = argumens[1];
            string author = argumens[2];

            Article article = new Article(title, content, author);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandsFromUser = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandsFromUser[0];
                string newArgument = string.Empty;
                newArgument = SetNewArguments(commandsFromUser, newArgument);
                ExecuteCommands(article, command, newArgument);
            }

            Console.WriteLine(article);
        }

        private static string SetNewArguments(string[] commandsFromUser, string newArgument)
        {
            for (int index = 1; index < commandsFromUser.Length; index++)
            {
                int count = index;
                if (count < commandsFromUser.Length - 1)
                {
                    newArgument += commandsFromUser[index] + " ";
                    count++;
                }
                else
                {
                    newArgument += commandsFromUser[index];
                }
            }

            return newArgument;
        }

        private static void ExecuteCommands(Article article, string command, string newArgument)
        {
            switch (command)
            {
                case "Edit:": article.Edit(newArgument); break;
                case "ChangeAuthor:": article.ChangeAuthor(newArgument); break;
                case "Rename:": article.Rename(newArgument); break;
            }
        }
    }
}
