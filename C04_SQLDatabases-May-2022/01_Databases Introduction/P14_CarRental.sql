CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(64) NOT NULL,
	DailyRate FLOAT(1),
	WeeklyRate FLOAT(1),
	MonthlyRate FLOAT(1),
	WeekendRate FLOAT(1)
)

INSERT INTO dbo.Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
	('Category1', 4.5, 5.2, 8, 6),
	('Category2', 6.7, 2.5, 7.2, 4),
	('Category3', 5.2, 1.2, 3.6, 4)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(8),
	Manufacturer VARCHAR(64),
	Model VARCHAR(32),
	CarYear DATE,
	CategoryId INT,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(32),
	Available BIT NOT NULL
)

ALTER TABLE dbo.Cars
ADD CONSTRAINT FK_Category
FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(Id)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES
	('VT5140BM', 'Manufacturer1', 'Model1', NULL, 2, 4, 'Condition1', 0),
	('BA5140BM', 'Manufacturer2', 'Model2', NULL, 1, 4, 'Condition1', 1),
	('SM5140BM', 'Manufacturer3', 'Model3', NULL, 3, 4, 'Condition1', 1)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(64) NOT NULL,
	LastName NVARCHAR(64) NOT NULL,
	Title NVARCHAR(32),
	Notes NVARCHAR(64)
)

INSERT INTO dbo.Employees(FirstName, LastName, Title, Notes)
VALUES
	('Pesho1', 'Peshev1', 'Title1', 'Note1'),
	('Pesho2', 'Peshev2', 'Title2', 'Note2'),
	('Pesho3', 'Peshev3', 'Title3', NULL)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(10) NOT NULL,
	FullName NVARCHAR(64) NOT NULL,
	[Address] NVARCHAR(64) NOT NULL,
	City NVARCHAR(64) NOT NULL,
	ZIPCode VARCHAR(4) NOT NULL,
	NOTES NVARCHAR(64)
)

INSERT INTO dbo.Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, NOTES)
VALUES
	('1052000000', 'Pesho Peshev', 'Address', 'City', '5140', NULL), 
	('1052330000', 'Gosho Peshev', 'Address1', 'City1', '5140', NULL), 
	('1052050000', 'GOho Peshev', 'Address2', 'City2', '5140', NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES dbo.Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES dbo.Customers(Id),
	CarId INT FOREIGN KEY REFERENCES dbo.Cars(Id),
	TankLevel NVARCHAR(128),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage FLOAT,
	StartData DATETIME2,
	EndData DATETIME2,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT,
	OrderStatus NVARCHAR(32),
	Notes NVARCHAR(128)
)

INSERT INTO dbo.RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartData, 
EndData, TotalDays, RateApplied, OrderStatus, Notes)
VALUES
	(1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(2, 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
	(3, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)