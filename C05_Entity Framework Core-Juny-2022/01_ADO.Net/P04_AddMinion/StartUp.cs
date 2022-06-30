namespace P04_AddMinion
{
    using System;
    using System.Data.SqlClient;
    using System.Text;

    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;DataBase=MinionsDB;Integrated Security=True";
        private const string SUCCESSFULLY_ADDED_NEW_ENTITY_MESSAGE = "{0} {1} was added to the database.";

        private static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            string[] minionTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] villainTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionTokens[1];
            string minionTown = minionTokens[3];

            string villainName = villainTokens[1];

            try
            {
                using SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);

                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();

                int townId = GetTownId(sqlConnection, transaction, minionTown);
                int minnionId = GetMinionId(sqlConnection, transaction, minionTokens, townId);
                int villainId = GetVillainId(sqlConnection, transaction, villainName);
                AddMinionToVillain(sqlConnection, transaction, minnionId, villainId, minionName, villainName);

                transaction.Commit();
                Console.WriteLine(sb.ToString().TrimEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static int GetTownId(SqlConnection connection, SqlTransaction transaction, string townName)
        {
            string townIdQuery = @"SELECT [Id]
	                                FROM dbo.[Towns]
	                                WHERE [Name] LIKE @townName";

            SqlCommand townIdCmd = new SqlCommand(townIdQuery, connection, transaction);
            townIdCmd.Parameters.AddWithValue("@townName", townName);

            object idAsObject = townIdCmd.ExecuteScalar();

            bool isTownNull = idAsObject == null;
            if (isTownNull)
            {
                AddTown(connection, transaction, townName);

                string message = string.Format(SUCCESSFULLY_ADDED_NEW_ENTITY_MESSAGE, "Town", townName);
                sb.AppendLine(message);
            }

            idAsObject = townIdCmd.ExecuteScalar();
            return (int)idAsObject;
        }

        private static int GetMinionId(SqlConnection connection, SqlTransaction transaction, string[] minionTokens, int townId)
        {
            string name = minionTokens[1];
            int age = int.Parse(minionTokens[2]);

            string minionIdQuery = @"SELECT [Id]
	                                    FROM dbo.[Minions]
	                                    WHERE [Name] LIKE @name AND [Age] = @age AND [TownId] = @townId";

            SqlCommand minnionIdCmd = new SqlCommand(minionIdQuery, connection, transaction);
            minnionIdCmd.Parameters.AddWithValue("@name", name);
            minnionIdCmd.Parameters.AddWithValue("@age", age);
            minnionIdCmd.Parameters.AddWithValue("@townId", townId);

            object minnionIdAsObj = minnionIdCmd.ExecuteScalar();
            bool isNull = minnionIdAsObj == null;
            if (isNull)
            {
                AddMinion(connection, transaction, townId, name, age);
            }

            minnionIdAsObj = minnionIdCmd.ExecuteScalar();

            return (int)minnionIdAsObj;
        }

        private static int GetVillainId(SqlConnection connection, SqlTransaction transaction, string villainName)
        {
            string villainIdQuery = @"SELECT [Id]
	                                    FROM dbo.[Villains]
	                                    WHERE [Name] LIKE @name";

            SqlCommand villaindIdCmd = new SqlCommand(villainIdQuery, connection, transaction);
            villaindIdCmd.Parameters.AddWithValue("@name", villainName);

            object villaindIdAsObj = villaindIdCmd.ExecuteScalar();
            if (villaindIdAsObj == null)
            {
                AddVillain(connection, transaction, villainName);
            }

            villaindIdAsObj = villaindIdCmd.ExecuteScalar();
            return (int)villaindIdAsObj;
        }

        private static void AddMinionToVillain(SqlConnection connection, SqlTransaction transaction, int minionId, int villainId, string minionName, string villainName)
        {
            string insertMinionToVillainQuery = @"INSERT INTO dbo.[MinionsVillains]([MinionId], [VillainId])
                                                    VALUES (@minionId, @villainId)";

            SqlCommand insertCmd = new SqlCommand(insertMinionToVillainQuery, connection, transaction);
            insertCmd.Parameters.AddWithValue("@minionId", minionId);
            insertCmd.Parameters.AddWithValue("@villainId", villainId);

            insertCmd.ExecuteNonQuery();
            sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void AddTown(SqlConnection connection, SqlTransaction transaction, string townName)
        {
            string insertNewTownQuery = @"INSERT INTO dbo.[Towns]([Name])
                                                VALUES(@townName)";

            SqlCommand insertTownCmd = new SqlCommand(insertNewTownQuery, connection, transaction);
            insertTownCmd.Parameters.AddWithValue("@townName", townName);
            insertTownCmd.ExecuteNonQuery();
        }

        private static void AddMinion(SqlConnection connection, SqlTransaction transaction, int townId, string name, int age)
        {
            string insertNewMinnion = @"INSERT INTO dbo.[Minions]([Name], [Age], [TownId])
                                            VALUES (@name, @age, @townId)";

            SqlCommand insertMinnionCmd = new SqlCommand(insertNewMinnion, connection, transaction);

            insertMinnionCmd.Parameters.AddWithValue("@name", name);
            insertMinnionCmd.Parameters.AddWithValue("@age", age);
            insertMinnionCmd.Parameters.AddWithValue("@townId", townId);

            insertMinnionCmd.ExecuteNonQuery();
        }

        private static void AddVillain(SqlConnection connection, SqlTransaction transaction, string villainName)
        {
            string insertVillaindQuery = @"INSERT INTO dbo.[Villains]([Name], [EvilnessFactorId])
                                                VALUES (@name, @factorId)";

            SqlCommand insertMinnionCmd = new SqlCommand(insertVillaindQuery, connection, transaction);
            insertMinnionCmd.Parameters.AddWithValue("@name", villainName);
            insertMinnionCmd.Parameters.AddWithValue("@factorId", 4);
            insertMinnionCmd.ExecuteNonQuery();

            string message = string.Format(SUCCESSFULLY_ADDED_NEW_ENTITY_MESSAGE, "Villain", villainName);
            sb.AppendLine(message);
        }
    }
}
