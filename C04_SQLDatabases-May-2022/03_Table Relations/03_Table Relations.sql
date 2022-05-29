-- Problem 1
CREATE DATABASE TableRelation

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(32) NOT NULL
)

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(64) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO dbo.Passports(PassportID, PassportNumber)
VALUES
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2')

INSERT INTO dbo.Persons(FirstName, Salary, PassportID)
VALUES 
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

SELECT *
	FROM dbo.Persons AS p
	JOIN dbo.Passports AS pass ON p.PassportID = pass.PassportID

-- Problem 2
CREATE TABLE Manufacturers
(
	[ManufacturerID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(64) NOT NULL,
	[EstablishedOn] DATE NOT NULL
)

CREATE TABLE Models
(
	[ModelID] INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(32) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO dbo.Manufacturers([Name], [EstablishedOn])
VALUES 
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966');

INSERT INTO dbo.Models([Name], [ManufacturerID])
VALUES	
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3);

SELECT * 
	FROM dbo.Models AS m
	JOIN dbo.Manufacturers AS man ON man.ManufacturerID = m.ManufacturerID

-- Problem 3

CREATE TABLE Students
(
	[StudentID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(64) NOT NULL
)

CREATE TABLE Exams
(
	[ExamID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(64) NOT NULL
)

CREATE TABLE StudentsExams
(
	[StudentID] INT FOREIGN KEY REFERENCES Students(StudentID),
	[ExamID] INT FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY ([StudentID],[ExamID])
)

INSERT INTO dbo.Students([Name])
VALUES	
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO dbo.Exams([Name])
VALUES	
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO dbo.StudentsExams([StudentID], [ExamID])
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)


SELECT s.[Name], e.[Name]
	FROM dbo.Students AS s
	JOIN dbo.StudentsExams AS sx ON sx.StudentID = s.StudentID
	JOIN dbo.Exams AS e ON e.ExamID = sx.ExamID

-- Problem 4

CREATE TABLE Teachers
(
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(64) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES dbo.Teachers([TeacherID])
)

INSERT INTO dbo.Teachers([Name], [ManagerID])
VALUES 
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

-- Problem 5
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities
(
	[CityID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	[CustomerID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	[Birhday] DATE NOT NULL,
	[CityID] INT FOREIGN KEY REFERENCES dbo.Cities([CityID])
)

CREATE TABLE Orders
(
	[OrderID] INT PRIMARY KEY IDENTITY(1,1),
	[CustomerID] INT FOREIGN KEY REFERENCES dbo.Customers([CustomerID])
)

CREATE TABLE ItemTypes
(
	[ItemTypeID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50)
)

CREATE TABLE Items
(
	[ItemID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES dbo.ItemTypes([ItemTypeID])
)

CREATE TABLE OrderItems
(
	[OrderID] INT FOREIGN KEY REFERENCES dbo.Orders([OrderID]),
	[ItemID] INT FOREIGN KEY REFERENCES dbo.Items([ItemID]),
	PRIMARY KEY ([OrderID], [ItemID])
)

-- Problem 6
CREATE DATABASE University
USE University

CREATE TABLE Majors
(
	[MajorID] INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	[StudentID] INT PRIMARY KEY IDENTITY(1,1),
	[StudentNumber] VARCHAR(10) NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES dbo.Majors([MajorID])
)

CREATE TABLE Payments
(
	[PaymentID] INT PRIMARY KEY IDENTITY(1,1),
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(15,2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES dbo.Students([StudentID])
)

CREATE TABLE Subjects
(
	[SubjectID] INT PRIMARY KEY IDENTITY(1,1),
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
	[StudentID] INT FOREIGN KEY REFERENCES dbo.Students([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES dbo.Subjects([SubjectID]),
	PRIMARY KEY ([StudentID], [SubjectID])
)

-- Problem 9
USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation 
	FROM dbo.Mountains AS m
	JOIN dbo.Peaks AS p ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY P.Elevation DESC