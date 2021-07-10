namespace Problem_3
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "end";

        public static void Main()
        {
            List<string> chat = new List<string>();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arguments[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    Print(chat);
                    break;
                }

                string command = arguments[0];
                ExecuteCommand(chat, command, arguments);
            }
        }

        private static void ExecuteCommand(List<string> chat, string command, string[] arguments)
        {
            switch (command)
            {
                case "Chat":
                    string messageToAdd = arguments[1];
                    Chat(chat, messageToAdd);
                    break;
                case "Delete":
                    string messageToDelete = arguments[1];
                    Delete(chat, messageToDelete);
                    break;
                case "Edit":
                    string messageToEdit = arguments[1];
                    string editedVersion = arguments[2];
                    Edit(chat, messageToEdit, editedVersion);
                    break;
                case "Pin":
                    string messageToPin = arguments[1];
                    Pin(chat, messageToPin);
                    break;
                case "Spam":
                    Spam(chat, arguments);
                    break;
            }
        }

        private static void Chat(List<string> chat, string messageToAdd)
        {
            chat.Add(messageToAdd);
        }

        private static void Delete(List<string> chat, string messageToDelete)
        {
            bool isMessageExist = CheckIfMessageExist(chat, messageToDelete);

            if (isMessageExist)
            {
                chat.Remove(messageToDelete);
            }
        }

        private static void Edit(List<string> chat, string messageToEdit, string editedVersion)
        {
            bool isMessageExist = CheckIfMessageExist(chat, messageToEdit);

            if (isMessageExist)
            {
                int index = chat.IndexOf(messageToEdit);
                chat.Remove(messageToEdit);
                chat.Insert(index, editedVersion);
            }
        }

        private static void Pin(List<string> chat, string messageToPin)
        {
            bool isMessageExist = CheckIfMessageExist(chat, messageToPin);

            if (isMessageExist)
            {
                chat.Remove(messageToPin);
                chat.Add(messageToPin);
            }
        }

        private static void Spam(List<string> chat, string[] messages)
        {
            for (int index = 1; index < messages.Length; index++)
            {
                chat.Add(messages[index]);
            }
        }

        private static bool CheckIfMessageExist(List<string> chat, string message)
        {
            bool isExist = chat.Contains(message);

            return isExist;
        }

        private static void Print(List<string> chat)
        {
            Console.WriteLine(string.Join(Environment.NewLine, chat));
        }
    }
}
