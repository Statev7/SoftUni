namespace P01_InitialSetup
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string ConnectionStringWithOutDataBase = @"Server=.;Integrated Security=True";
        private const string ConnectionString = @"Server=.;DataBase=MinionsDB;Integrated Security=True";

        public static void Main()
        {
            var queries = DataBaseQueries();
            CreateDataBase(queries);

            var dataToInsert = DataQueries();
            InsertData(dataToInsert);
        }

        private static void CreateDataBase(List<string> queries)
        {

            using (var sqlConnection = new SqlConnection(ConnectionStringWithOutDataBase))
            {
                sqlConnection.Open();

                foreach (var query in queries)
                {
                    var command = new SqlCommand(query, sqlConnection);
                    command.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        private static void InsertData(List<string> dataQueries)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                foreach (var query in dataQueries)
                {
                    var command = new SqlCommand(query, sqlConnection);
                    command.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        private static List<string> DataBaseQueries()
        {
            var databaseQuery = @"CREATE DATABASE MinionsDB";
            var useDataBaseQuery = @"USE MinionsDB";

            var countriesQuery = @"CREATE TABLE Countries
                                (
	                                [Id] INT PRIMARY KEY IDENTITY(1,1),
	                                [Name] VARCHAR(50)
                                )";

            var townQuery = @"CREATE TABLE Towns
                            (
	                            [Id] INT PRIMARY KEY IDENTITY(1,1),
	                            [Name] VARCHAR(50),
	                            [CountryCode] INT FOREIGN KEY REFERENCES Countries([Id])
                            )";

            var minionsQuery = @"CREATE TABLE Minions
                                (
	                                [Id] INT PRIMARY KEY IDENTITY(1,1),
	                                [Name] VARCHAR(50),
	                                [Age] INT,
	                                [TownId] INT FOREIGN KEY REFERENCES Towns([Id])
                                )";

            var evilnessFactorsQuery = @"CREATE TABLE EvilnessFactors
                                       (
	                                       [Id] INT PRIMARY KEY IDENTITY(1, 1),
	                                       [Name] VARCHAR(50) CHECK([Name] IN ('super good', 'good', 'bad', 'evil', 'super evil'))
                                       )";

            var villainsQuery = @"CREATE TABLE Villains
                                (
	                                [Id] INT PRIMARY KEY IDENTITY(1, 1),
	                                [Name] VARCHAR(50),
	                                [EvilnessFactorId] INT FOREIGN KEY REFERENCES EvilnessFactors([Id])
                                )";

            var minionsVillainsQuery = @"CREATE TABLE MinionsVillains
                                        (
	                                        [MinionId] INT FOREIGN KEY REFERENCES Minions([Id]),
	                                        [VillainId] INT FOREIGN KEY REFERENCES Villains([Id]),
	                                        PRIMARY KEY ([MinionId], [VillainId])
                                        )";

            var list = new List<string>() { databaseQuery, useDataBaseQuery, countriesQuery, townQuery, minionsQuery, evilnessFactorsQuery, villainsQuery, minionsVillainsQuery };

            return list;
        }

        private static List<string> DataQueries()
        {
            var countriesQuery = @"INSERT INTO Countries([Name])
                                    VALUES ('Countrie1'), ('Countrie2'), ('Countrie3'), ('Countrie4'), ('Countrie5')";

            var townQuery = @"INSERT INTO Towns([Name], [CountryCode])
                                VALUES ('town1', 1), ('town2', 2), ('town3', 3), ('town4', 4), ('town5', 5)";

            var minionsQuery = @"INSERT INTO Minions([Name], [Age], [TownId])
                                   VALUES ('name1', 10, 1), ('name2', 12, 2), ('name3', 14, 3), ('name4', 16, 4), ('name5', 18, 5)";

            var evilnessQuery = @"INSERT INTO EvilnessFactors([Name])
                                    VALUES ('super good'), ('good'), ('bad'), ('evil'), ('super evil')";

            var villainsQuery = @"INSERT INTO Villains([Name], [EvilnessFactorId])
                                    VALUES ('Villains1', 1), ('Villains2', 2), ('Villains3', 3), ('Villains4', 4), ('Villains5', 5)";

            var minionsVillainsQuery = @"INSERT INTO MinionsVillains([MinionId], [VillainId])
                                            VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5)";

            var list = new List<string>() { countriesQuery, townQuery, minionsQuery, evilnessQuery, villainsQuery, minionsVillainsQuery };

            return list;
        }

    }
}
