namespace P01_CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P01_CompanyRoster.Models;

    public class StartUp
    {
        public static void Main()
        {
            int employeeCount = int.Parse(Console.ReadLine());

            List<Employee> allEmployees = new List<Employee>();

            for (int i = 0; i < employeeCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = arguments[0];
                decimal salary = decimal.Parse(arguments[1]);
                string department = arguments[2];

                Employee employee = new Employee(name, salary, department);
                allEmployees.Add(employee);
            }

            string theMostExpensiveDeparment = FindTheMostExpensiveDeparment(ref allEmployees);
            PrintResult(allEmployees, theMostExpensiveDeparment);
        }

        private static string FindTheMostExpensiveDeparment(ref List<Employee> allEmployees)
        {
            decimal max = decimal.MinValue;
            string theMostExpensiveDeparment = string.Empty;

            for (int i = 0; i < allEmployees.Count; i++)
            {
                decimal sum = 0;
                string departmen = allEmployees[i].Department;

                var allEmployeesWithSameDepartment = allEmployees
                    .Where(x => x.Department == departmen)
                    .ToList();

                foreach (var item in allEmployeesWithSameDepartment)
                {
                    sum += item.Salary;
                }

                sum /= allEmployeesWithSameDepartment.Count();

                if (sum > max)
                {
                    max = sum;
                    theMostExpensiveDeparment = departmen;
                }
            }

            return theMostExpensiveDeparment;
        }

        private static void PrintResult(List<Employee> allEmployees, string theMostExpensiveDeparment)
        {
            var orderedEmployees = allEmployees
                            .Where(x => x.Department == theMostExpensiveDeparment)
                            .OrderByDescending(x => x.Salary)
                            .ToList();

            Console.WriteLine($"Highest Average Salary: {theMostExpensiveDeparment}");
            foreach (var employee in orderedEmployees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
