--CREATE DATABASE Zoo
--USE Zoo

CREATE TABLE Owners
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50) NULL
)

CREATE TABLE AnimalTypes
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[AnimalType] VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[AnimalTypeId] INT FOREIGN KEY REFERENCES AnimalTypes([Id]) NOT NULL
)

CREATE TABLE Animals
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(30) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[OwnerId] INT FOREIGN KEY REFERENCES Owners([Id]) NULL,
	[AnimalTypeId] INT FOREIGN KEY REFERENCES AnimalTypes([Id]) NOT NULL
)

CREATE TABLE AnimalsCages
(
	[CageId] INT FOREIGN KEY REFERENCES Cages([Id]) NOT NULL,
	[AnimalId] INT FOREIGN KEY REFERENCES Animals([Id]) NOT NULL,
	PRIMARY KEY([CageId], [AnimalId])
)

CREATE TABLE VolunteersDepartments
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[DepartmentName] VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50) NULL,
	[AnimalId] INT FOREIGN KEY REFERENCES Animals([Id]) NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES VolunteersDepartments([Id]) NOT NULL
)

-- Problem 2
INSERT INTO dbo.Volunteers([Name], [PhoneNumber], [Address], [AnimalId], [DepartmentId])
VALUES
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO dbo.Animals([Name], [BirthDate], [OwnerId], [AnimalTypeId])
VALUES
	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4)

-- Problem 3
UPDATE dbo.[Animals]
SET [OwnerId] = 4
WHERE [OwnerId] IS NULL

-- Problem 4
DELETE FROM dbo.[Volunteers]
WHERE [DepartmentId] = (SELECT [Id]
				FROM dbo.[VolunteersDepartments]
				WHERE [DepartmentName] = 'Education program assistant')

DELETE FROM dbo.[VolunteersDepartments]
WHERE [DepartmentName] = 'Education program assistant'

-- Problem 5
SELECT [Name], [PhoneNumber], [Address], [AnimalId], [DepartmentId]
	FROM dbo.[Volunteers]
	ORDER BY [Name] ASC, [AnimalId] ASC, [DepartmentId] ASC

-- Problem 6
SELECT [a].[Name], [at].[AnimalType], FORMAT([a].[BirthDate], 'dd.MM.yyyy') AS [BirthDate]
	FROM dbo.[Animals] AS [a]
		LEFT JOIN dbo.[AnimalTypes] AS [at] ON [a].[AnimalTypeId] = [at].[Id]
	ORDER BY [a].[Name] ASC

-- Problem 7
SELECT TOP(5) [o].[Name], COUNT([a].[Id]) AS [CountOfAnimals]
	FROM dbo.Owners AS [o]
		JOIN dbo.[Animals] AS [a] ON [o].[Id] = [a].[OwnerId]
	GROUP BY [o].[Name]
	ORDER BY [CountOfAnimals] DESC

-- Problem 8
SELECT CONCAT([o].[Name], '-', [a].[Name]) AS [OwnersAnimals], [o].[PhoneNumber], [ac].[CageId]
	FROM dbo.[Owners] AS [o]
		JOIN dbo.[Animals] AS [a] ON [o].[Id] = [a].[OwnerId]
		JOIN dbo.[AnimalsCages] AS [ac] ON [a].[Id] = [ac].[AnimalId]
		JOIN dbo.[Cages] AS [c] ON [ac].[CageId] = [c].[Id]
		JOIN dbo.[AnimalTypes] AS [at] ON [a].[AnimalTypeId] = [at].[Id]
	WHERE [at].[AnimalType] = 'mammals'
	ORDER BY [o].[Name] ASC, [a].[Name] DESC

-- Problem 9
SELECT [temp].[Name], [temp].[PhoneNumber], SUBSTRING([temp].[Address], [temp].[Index] + 2, LEN([temp].[Address])) AS [Address]
	FROM(
		SELECT [v].[Name], [v].[PhoneNumber], [v].[Address], CHARINDEX(',', [v].[Address]) AS [Index]
			FROM dbo.[Volunteers] AS [v]
				JOIN dbo.[VolunteersDepartments] AS [vd] ON [v].[DepartmentId] = [vd].[Id] 
		WHERE [vd].[DepartmentName] = 'Education program assistant' AND [v].[Address] LIKE '%Sofia%') 
			AS [temp]
	ORDER BY [temp].[Name] ASC

-- Problem 10
SELECT [a].[Name], DATEPART(YEAR, [a].[BirthDate]) AS [BirthYear], [at].[AnimalType]
	FROM dbo.[Animals] AS [a]
		LEFT JOIN dbo.[AnimalTypes] AS [at] ON [a].[AnimalTypeId] = [at].[Id]
	WHERE ([a].[OwnerId] IS NULL) AND (DATEDIFF(YEAR, [a].[BirthDate], '01/01/2022') < 5 AND [at].[AnimalType] <> 'Birds')
	ORDER BY [a].[Name] ASC

-- Problem 11
CREATE FUNCTION  udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(256))
RETURNS INT
BEGIN
	RETURN (SELECT COUNT([vd].[Id])
				FROM dbo.[VolunteersDepartments] AS [vd]
					JOIN dbo.[Volunteers] AS [v] ON [vd].[Id] = [v].[DepartmentId]
			WHERE [vd].[DepartmentName] = @VolunteersDepartment)
END

-- Problem 12
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(64))
AS
	DECLARE @OwnerName VARCHAR(64);

	SET @OwnerName = (SELECT [o].[Name]
						FROM dbo.[Animals] AS [a]
							LEFT JOIN dbo.[Owners] AS [o] ON [a].[OwnerId] = [o].[Id]
						WHERE [a].[Name] = @AnimalName)

	IF(@OwnerName IS NULL)
		SELECT @AnimalName AS [Name], 'For adoption' AS [OwnersName]
	ELSE 
		SELECT @AnimalName AS [Name], @OwnerName AS [OwnersName]

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'


