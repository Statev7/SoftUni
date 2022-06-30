namespace P08_IncreaseMinionAge
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;Database=MinionsDB;Trusted_Connection=True";

        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            using SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();

            UpdateMinions(input, sqlConnection);
            DisplayMinions(sqlConnection);
        }

        private static void UpdateMinions(int[] input, SqlConnection sqlConnection)
        {
            for (int index = 0; index < input.Length; index++)
            {
                string query = @"UPDATE Minions
                               SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                             WHERE Id = @Id";

                var command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@Id", input[index]);

                command.ExecuteNonQuery();
            }
        }

        private static void DisplayMinions(SqlConnection sqlConnection)
        {
            var sb = new StringBuilder();

            string quary = @"SELECT [Name], [Age] 
                                FROM dbo.[Minions]";

            var command = new SqlCommand(quary, sqlConnection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]} {reader["Age"]}");
            }

            string resultAsString = sb.ToString().TrimEnd();
            Console.WriteLine(resultAsString);
        }
    }
}
