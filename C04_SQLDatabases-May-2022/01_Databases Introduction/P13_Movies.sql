CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(32) NOT NULL,
	Notes VARCHAR(128)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(32) NOT NULL,
	Notes VARCHAR(128)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(64) NOT NULL,
	Notes VARCHAR(128)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(64) NOT NULL,
	DirectorId INT,
	CopyrightYear DATE,
	Lenght VARCHAR(16),
	GenreId INT,
	CategoryId INT,
	Rating DECIMAL(3, 2),
	Notes VARCHAR(128),
	FOREIGN KEY (DirectorId) REFERENCES dbo.Directors(Id),
	FOREIGN KEY (GenreId) REFERENCES dbo.Genres(Id),
	FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(Id)
)

INSERT INTO dbo.Directors(DirectorName, Notes)
VALUES
	('Gosho', 'Idk'),
	('Gosho2', 'Idk'),	
	('Gosho3', 'Idk'),	
	('Gosho4', NULL),	
	('Gosh5', NULL)

INSERT INTO dbo.Genres(GenreName, Notes)
VALUES
	('Test1', 'genre1'),
	('Test2', 'genre2'),
	('Test3', NULL),
	('Test4', 'genre3'),
	('Test5', NULL)

INSERT INTO dbo.Categories(CategoryName, Notes)
VALUES 
	('CategoryName1', 'note1'),
	('CategoryName2', 'note2'),
	('CategoryName3', 'note3'),
	('CategoryName4', 'note4'),
	('CategoryName5', 'note5')

INSERT INTO dbo.Movies(Title, DirectorId, Lenght, GenreId, CategoryId, Rating, Notes)
VALUES
	('Movie1', 2, '3:54', 1, 5, 7.23, NULL),
	('Movie2', 1, '3:54', 1, 1, 8.93, NULL),
	('Movie3', 2, '3:54', 3, 2, 5.3, NULL),
	('Movie4', 3, '3:54', 5, 3, 9.99, NULL),
	('Movie5', 4, '3:54', 4, 4, 8, NULL)