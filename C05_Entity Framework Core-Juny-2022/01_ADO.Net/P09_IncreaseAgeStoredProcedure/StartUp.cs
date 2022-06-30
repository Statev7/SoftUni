namespace P09_IncreaseAgeStoredProcedure
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;Database=MinionsDB;Trusted_Connection=True";

        public static void Main()
        {
            int minionId = int.Parse(Console.ReadLine());

            SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();

            UpdateMinion(minionId, sqlConnection);
            DisplayMinion(sqlConnection, minionId);
        }

        private static void UpdateMinion(int minionId, SqlConnection sqlConnection)
        {
            string quary = @"EXEC dbo.usp_GetOlder @Id";

            var command = new SqlCommand(quary, sqlConnection);
            command.Parameters.AddWithValue("@Id", minionId);
            command.ExecuteNonQuery();
        }

        private static void DisplayMinion(SqlConnection sqlConnection, int minionId)
        {
            string quary = @"SELECT [Name], [Age] 
                                FROM dbo.[Minions] 
                                WHERE [Id] = @Id";

            var command = new SqlCommand(quary, sqlConnection);
            command.Parameters.AddWithValue("@Id", minionId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
            }
        }
    }
}
