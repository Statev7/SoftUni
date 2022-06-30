namespace P02_VillainNames
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        private const string ConnectionString = @"Server=.;DataBase=MinionsDB;Integrated Security=True";

        public static void Main()
        {
            var sb = new StringBuilder();

            var query = @"SELECT [v].[Name], COUNT([mv].[VillainId]) AS [MinionsCount]
	                        FROM dbo.[Villains] AS [v]
		                        JOIN dbo.[MinionsVillains] AS [mv] ON [v].[Id] = [mv].[VillainId]
	                        GROUP BY [v].[Name]
	                        HAVING COUNT([mv].[VillainId]) > 3
	                        ORDER BY [MinionsCount] DESC";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string villainName = reader["Name"].ToString();
                        int minionsCount = (int)reader["MinionsCount"];

                        sb.AppendLine($"{villainName} - {minionsCount}");
                    }
                }
            }

            var resultAsString = sb.ToString().TrimEnd();
            Console.WriteLine(resultAsString);
        }
    }
}
