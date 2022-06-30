namespace P06_RemoveVillain
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;DataBase=MinionsDB;Integrated Security=True;";

        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            using SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();

            try
            {
                string villain = GetVillain(sqlConnection, villainId);

                SqlTransaction transaction = sqlConnection.BeginTransaction();
                string minionMessage = ReleasesMinions(villainId, sqlConnection, transaction);

                DeleteVillain(villainId, sqlConnection, transaction);
                PrintOutput(villain, minionMessage);

                transaction.Commit();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void DeleteVillain(int villainId, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string query = @"DELETE FROM dbo.[Villains]
                                    WHERE [Id] = @Id";

            SqlCommand deleteVillandCmd = new SqlCommand(query, sqlConnection, transaction);
            deleteVillandCmd.Parameters.AddWithValue("@Id", villainId);

            deleteVillandCmd.ExecuteNonQuery();
        }

        private static string ReleasesMinions(int villainId, SqlConnection sqlConnection, SqlTransaction transaction)
        {
            string query = @"DELETE FROM dbo.[MinionsVillains]
                                WHERE [VillainId] = @Id";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection, transaction);
            sqlCommand.Parameters.AddWithValue(@"Id", villainId);

            int affectedMinionsCount = sqlCommand.ExecuteNonQuery();
            string result = $"{affectedMinionsCount} minions were released.";

            return result;
        }

        private static string GetVillain(SqlConnection sqlConnection, int villainId)
        {
            string quary = @"SELECT [Name]
	                            FROM dbo.[Villains]
	                            WHERE [Id] = @Id";

            SqlCommand command = new SqlCommand(quary, sqlConnection);
            command.Parameters.AddWithValue("@Id", villainId);
            string name = command.ExecuteScalar().ToString();

            if (name == null)
            {
                throw new ArgumentException("No such villain was found.");
            }

            return name;
        }

        private static void PrintOutput(string villain, string minionMessage)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{villain} was deleted.");
            sb.AppendLine(minionMessage);
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
