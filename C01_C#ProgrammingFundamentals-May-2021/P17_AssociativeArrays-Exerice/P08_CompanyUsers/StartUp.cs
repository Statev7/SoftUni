namespace P08_CompanyUsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        const string COMMAND_TO_STOP = "End";

        public static void Main()
        {
            var companyUsers = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] arguments = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                bool isStopCommnad = arguments[0] == COMMAND_TO_STOP;
                if (isStopCommnad)
                {
                    Print(companyUsers);
                    break;
                }

                string companyName = arguments[0].Trim();
                string id = arguments[1].Trim();
                AddCompanyWithUser(companyUsers, companyName, id);
            }
        }

        private static void AddCompanyWithUser(Dictionary<string, List<string>> companyUsers, string companyName, string id)
        {
            bool isCompanyExist = companyUsers.ContainsKey(companyName);
            bool isIdExist = false;

            foreach (var user in companyUsers.Where(x => x.Key == companyName))
            {
                foreach (var item in user.Value)
                {
                    if (item == id)
                    {
                        isIdExist = true;
                        break;
                    }
                }
            }

            if (isCompanyExist && isIdExist == false)
            {
                companyUsers[companyName].Add(id);
            }
            else if(isCompanyExist == false)
            {
                companyUsers.Add(companyName, new List<string>() { id });
            }
        }

        private static void Print(Dictionary<string, List<string>> companyUsers)
        {
            var orderedCompany = companyUsers
                .OrderBy(x => x.Key)
                .ToList();

            foreach (var company in orderedCompany)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var user in company.Value)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}
