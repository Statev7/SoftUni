namespace P05_ChangeTownNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string CONNECTION_STRING = @"Server=.;DataBase=MinionsDB;Integrated Security=True;";

        public static void Main()
        {
            string country = Console.ReadLine();

            try
            {
                using SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING);
                sqlConnection.Open();
                int? countryId = GetCountryId(country, sqlConnection);

                UpdateTowns(sqlConnection, countryId);
                DisplayTowns(sqlConnection, (int)countryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static int? GetCountryId(string country, SqlConnection sqlConnection)
        {
            string getCountryQuery = @"SELECT [Id] 
	                                    FROM dbo.[Countries]
	                                    WHERE [Name] LIKE @name";

            SqlCommand getCountryIdCmd = new SqlCommand(getCountryQuery, sqlConnection);
            getCountryIdCmd.Parameters.AddWithValue("@name", country);

            int? countryId = (int?)getCountryIdCmd.ExecuteScalar();
            return countryId;
        }

        private static void UpdateTowns(SqlConnection sqlConnection, int? countryId)
        {
            if (countryId == null)
            {
                throw new ArgumentException("No town names were affected.");
            }

            string updateQuery = @"UPDATE dbo.[Towns]
                                    SET [Name] = UPPER([Name])
                                    WHERE [CountryCode] = (SELECT [c].[Id]
	                                    FROM dbo.[Countries] AS [c]
	                                    WHERE [c].[Id] = @Id)";

            SqlCommand updateCmd = new SqlCommand(updateQuery, sqlConnection);
            updateCmd.Parameters.AddWithValue("@Id", countryId);
            int affectedRows = updateCmd.ExecuteNonQuery();

            Console.WriteLine($"{affectedRows} town names were affected. ");
        }

        private static void DisplayTowns(SqlConnection sqlConnection, int countryId)
        {
            string townsQuery = @"SELECT [Name]
	                                FROM dbo.[Towns]
	                                WHERE [CountryCode] = @Id";

            SqlCommand townsCommand = new SqlCommand(townsQuery, sqlConnection);
            townsCommand.Parameters.AddWithValue("@Id", countryId);

            using var reader = townsCommand.ExecuteReader();

            var townsList = new List<string>();

            while (reader.Read())
            {
                townsList.Add(reader["Name"].ToString());
            }

            Console.WriteLine($"[{string.Join(", ", townsList)}]");
        }
    }
}
