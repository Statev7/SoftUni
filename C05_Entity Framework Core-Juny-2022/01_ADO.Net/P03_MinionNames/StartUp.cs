namespace P03_MinionNames
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        private const string ConnectionString = @"Server=.;DataBase=MinionsDB;Integrated Security=True";
        private const string InvalidVillainErrorMessage = "No villain with ID {0} exists in the database.";
        private const string NoMinionsMessage = "(no minions)";

        public static void Main()
        {
            try
            {
                var result = GetVillainInformation();
                Console.WriteLine(result);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static string GetVillainInformation()
        {
            var sb = new StringBuilder();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var villainId = int.Parse(Console.ReadLine());

                var query = @"SELECT [Name]
	                        FROM dbo.[Villains]
	                        WHERE [Id] = @Id";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", villainId);

                var villainName = (string)command.ExecuteScalar();
                if (villainName == null)
                {
                    var message = string.Format(InvalidVillainErrorMessage, villainId);
                    throw new ArgumentException(message);
                }

                sb.AppendLine($"Villain: {villainName}");

                var minnionsResult = GetMinnionsInfo(villainId);
                sb.AppendLine(minnionsResult);
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetMinnionsInfo(int villainId)
        {
            var sb = new StringBuilder();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var query = @"SELECT m.[Name], m.[Age]
	                            FROM dbo.[Villains] AS [v]
		                            JOIN dbo.[MinionsVillains] AS [mv] ON [v].[Id] = [mv].[VillainId]
		                            JOIN dbo.[Minions] AS [m] ON [mv].[MinionId] = [m].[Id]
	                            WHERE [v].[Id] = @villainId
	                            ORDER BY m.[Name] ASC";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@villainId", villainId);
                
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return NoMinionsMessage;
                    }

                    int rowNumber = 1;
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        int age = (int)reader["age"];

                        sb.AppendLine($"{rowNumber++}. {name} {age}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
