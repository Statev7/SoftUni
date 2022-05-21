/* Problem 16 */

CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(64) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AddressText NVARCHAR(64),
	TownId INT FOREIGN KEY REFERENCES dbo.Towns(Id)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(64)
)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(64),
	MiddleName NVARCHAR(64),
	LastName NVARCHAR(64),
	JobTitle NVARCHAR(32),
	DepartmentId INT FOREIGN KEY REFERENCES dbo.Departments(Id),
	HireDate DATE,
	Salary DECIMAL(15,2),
	AddressId INT FOREIGN KEY REFERENCES dbo.Addresses(Id)
)

/* Problem 18 */

INSERT INTO dbo.Towns([Name])
VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO dbo.Departments([Name])
VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO dbo.Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES 
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02-01-2013', 3500),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03-02-2004', 4000),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08-28-2016', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12-09-2007', 3000),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '08-28-2016', 599.88)

/* Problem 19 */

SELECT * FROM dbo.Towns
SELECT * FROM dbo.Departments
SELECT * FROM dbo.Employees

/* Problem 20 */

SELECT * FROM dbo.Towns
ORDER BY [Name]

SELECT * FROM dbo.Departments
ORDER BY [Name]

SELECT * FROM dbo.Employees
ORDER BY [Salary] DESC

/* Problem 21 */

SELECT [Name]
	FROM dbo.Towns
ORDER BY [Name]

SELECT [Name] 
	FROM dbo.Departments
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary] 
	FROM dbo.Employees
ORDER BY [Salary] DESC

/* Problem 22 */
UPDATE dbo.Employees
SET [SALARY] = [Salary] * 1.1;

SELECT [SALARY] 
	FROM dbo.Employees

/* Problem 23 */

USE Hotel

UPDATE dbo.Payments 
SET [TaxRate] = [TaxRate] * 0.97;

SELECT [TaxRate]
	FROM dbo.Payments

/* Problem 24 */
TRUNCATE TABLE dbo.Occupancies 
