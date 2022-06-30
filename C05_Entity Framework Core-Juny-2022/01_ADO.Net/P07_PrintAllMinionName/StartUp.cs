namespace P07_PrintAllMinionName
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;DataBase=MinionsDB;Integrated Security=True;";

        public static void Main()
        {
            using SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
            sqlConnection.Open();

            var minionList = GetAllMinions(sqlConnection);
            PrintOutput(minionList);
        }

        private static List<string> GetAllMinions(SqlConnection sqlConnection)
        {
            var minionList = new List<string>();

            string query = @"SELECT [Name] 
                                FROM Minions";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                minionList.Add(reader["Name"].ToString());
            }

            return minionList;
        }

        private static void PrintOutput(List<string> minionList)
        {
            var output = new List<string>();

            for (int index = 0; index < minionList.Count / 2; index++)
            {
                output.Add(minionList[index]);
                output.Add(minionList[(minionList.Count - 1) - index]);
            }

            if (minionList.Count % 2 != 0)
            {
                output.Add(minionList[minionList.Count / 2]);
            }

            Console.WriteLine(string.Join(Environment.NewLine, output));
        }
    }
}
