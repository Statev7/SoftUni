namespace Problem_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "Statistics";
        const string REACHED_CAPACITY_ERROR_MESSAGE = "{0} reached the capacity!";

        public static void Main()
        {
            var allContacts = new Dictionary<string, Message>();
            int capacity = int.Parse(Console.ReadLine());

            while (true)
            {
                var arg = Console.ReadLine()
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommand = arg[0] == COMMAND_TO_STOP;
                if (isStopCommand)
                {
                    PrintResult(allContacts);
                    break;
                }

                string command = arg[0];
                switch (command)
                {
                    case "Add":
                        string username = arg[1];
                        int sent = int.Parse(arg[2]);
                        int received = int.Parse(arg[3]);
                        Add(allContacts, username, sent, received);
                        break;
                    case "Message":
                        string sender = arg[1];
                        string receiver = arg[2];
                        Message(allContacts, sender, receiver, capacity);
                        break;
                    case "Empty":
                        string usernameForRemove = arg[1];
                        Empty(allContacts, usernameForRemove);
                        break;
                }
            }
        }

        private static void Add(Dictionary<string, Message> allContacts, string username, int sent, int received)
        {
            bool isUserExist = allContacts.ContainsKey(username);
            if (isUserExist == false)
            {
                Message message = new Message(sent, received);
                allContacts.Add(username, message);
            }
        }

        private static void Message(Dictionary<string, Message> allContacts, string sender, string receiver, int capacity)
        {
            bool isValid = allContacts.ContainsKey(sender) && allContacts.ContainsKey(receiver);
            if (isValid)
            {
                allContacts[sender].Sent += 1;
                allContacts[receiver].Received += 1;

                bool isSenderNeedToRemove = capacity <= allContacts[sender].Sent + allContacts[sender].Received;
                bool isReceiverNeedToRemove = capacity <= allContacts[receiver].Sent + allContacts[receiver].Received;
                if (isSenderNeedToRemove)
                {
                    allContacts.Remove(sender);
                    Console.WriteLine(string.Format(REACHED_CAPACITY_ERROR_MESSAGE, sender));
                }
                if (isReceiverNeedToRemove)
                {
                    allContacts.Remove(receiver);
                    Console.WriteLine(string.Format(REACHED_CAPACITY_ERROR_MESSAGE, receiver));
                }
            }
        }

        private static void Empty(Dictionary<string, Message> allContacts, string username)
        {
            bool isExist = allContacts.ContainsKey(username);
            if (isExist)
            {
                allContacts.Remove(username);
            }
            if (username == "All")
            {
                allContacts.Clear();
            }
        }

        private static void PrintResult(Dictionary<string, Message> allContacts)
        {
            Console.WriteLine($"Users count: {allContacts.Count}");
            foreach (var user in allContacts
                .OrderByDescending(x => x.Value.Received)
                .ThenBy(x => x.Key))
            {
                int sum = user.Value.Sent + user.Value.Received;
                Console.WriteLine($"{user.Key} - {sum}");
            }
        }
    }

    public class Message
    {
        public Message(int sent, int received)
        {
            this.Sent = sent;
            this.Received = received;
        }

        public int Sent { get; set; }

        public int Received { get; set; }
    }
}
