CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(32) NOT NULL,
	LastName NVARCHAR(32) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO dbo.Employees(FirstName, LastName, Notes)
VALUES
	('Pesho', 'Peshev', NULL),
	('Pesho1', 'Peshev1', NULL),
	('Pesho2', 'Peshev2', NULL)

CREATE TABLE Customers
(
	AccountNumber VARCHAR(10) NOT NULL, 
	FirstName NVARCHAR(32) NOT NULL,
	LastName NVARCHAR(32) NOT NULL,
	PhoneNumber VARCHAR(10) NOT NULL,
	EmergencyName NVARCHAR(32) NOT NULL,
	EmergencyNumber VARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO dbo.Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
	('0123456789', 'Pesho1', 'Peshev1', '0123456789', 'EmergencyName', '0123456789', NULL),
	('0123456789', 'Pesho2', 'Peshev2', '0123456789', 'EmergencyName', '0123456789', NULL),
	('0123456789', 'Pesho3', 'Peshev3', '0123456789', 'EmergencyName', '0123456789', NULL)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(32) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO dbo.RoomStatus(RoomStatus, Notes)
VALUES
	('RoomStatus1', NULL),
	('RoomStatus2', NULL),
	('RoomStatus3', NULL)

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(64) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO dbo.RoomTypes(RoomType, Notes)
VALUES
	('RoomType1', NULL),
	('RoomType2', NULL),
	('RoomType3', NULL)

CREATE TABLE BedTypes
(
	BedTypes NVARCHAR(64) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO dbo.BedTypes(BedTypes, Notes)
VALUES
	('BedType1', NULL),
	('BedType2', NULL),
	('BedType3', NULL)

CREATE TABLE Rooms
(
	RoomNumber NVARCHAR(10) NOT NULL,
	RoomType NVARCHAR(64) FOREIGN KEY REFERENCES dbo.RoomTypes(RoomType),
	BedType NVARCHAR(64) FOREIGN KEY REFERENCES dbo.BedTypes(BedTypes),
	Rate FLOAT,
	RoomStatus NVARCHAR(32) FOREIGN KEY REFERENCES dbo.RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

INSERT INTO dbo.Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES	
	('123', 'RoomType1', 'BedType2', 7, 'RoomStatus1', NULL),
	('12345', 'RoomType2', 'BedType3', 5, 'RoomStatus2', NULL),
	('12372', 'RoomType3', 'BedType1', 8, 'RoomStatus3', NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT FOREIGN KEY REFERENCES dbo.Employees(Id),
	PaymentDate DATE,
	AccountNumber NVARCHAR(10),
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL(15,2),
	TaxRate FLOAT,
	TaxAmount DECIMAL(15,2),
	PaymentTotal DECIMAL(15,2),
	NOTES NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId)
VALUES
	(2),
	(3),
	(1)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	EmployeeId INT FOREIGN KEY REFERENCES dbo.Employees(Id),
	DateOccupied DATETIME2,
	AccountNumber VARCHAR(10),
	RoomNumber VARCHAR(10),
	RateApplied INT,
	PhoneCharge FLOAT,
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies(EmployeeId)
VALUES
	(1),
	(2),
	(3)