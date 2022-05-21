CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) 
	CHECK (DATALENGTH(Picture) <= 2097152),
	Height DECIMAL(15, 2),
	[Weight] DECIMAL(15, 2),
	Gender CHAR NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
);

INSERT INTO dbo.People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES 
	('Pesho1', NULL, 178, 60, 'M', '2001-12-31', 'Hiiii'),
	('Pesho2', NULL, 188, 68, 'M', '2001-11-15', 'Hiiii'),
	('Inka', NULL, 163, 50, 'F', '2002-02-02', 'Obicham kotki'),
	('Pesh4', NULL, 190, 80, 'M', '2000-12-31', 'Hi'),
	('Pesho5', NULL, 176, 62, 'M', '2002-12-31', 'Hi')

SELECT * FROM dbo.People