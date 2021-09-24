namespace Telephony.Core
{
    using System;

    using Telephony.Models;
    using Telephony.Models.Interfaces;

    public class Engine
    {
        public void Run()
        {
            var phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var sitesToVisit = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var smartPhone = new SmartPhone();
            var stationaryPhone = new StationaryPhone();

            Call(phoneNumbers, smartPhone, stationaryPhone);
            Browse(sitesToVisit, smartPhone);
        }

        private static void Call(string[] phoneNumbers, IPhone smartPhone, IPhone stationaryPhone)
        {
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string phoneNumber = phoneNumbers[i];

                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        Console.WriteLine(smartPhone.Call(phoneNumber));
                    }
                    else
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumber));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void Browse(string[] sitesToVisit, SmartPhone smartPhone)
        {
            for (int i = 0; i < sitesToVisit.Length; i++)
            {
                string siteUrl = sitesToVisit[i];

                try
                {
                    Console.WriteLine(smartPhone.Browse(siteUrl));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
