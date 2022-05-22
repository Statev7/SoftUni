-- Problem 2
SELECT * 
	FROM dbo.Departments 

-- Problem 3
SELECT [Name]
	FROM dbo.Departments

-- Problem 4
SELECT [FirstName], [LastName], [Salary]
	FROM dbo.Employees

-- Problem 5
SELECT [FirstName], [MiddleName], [LastName]
	FROM dbo.Employees

-- Problem 6
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS [Full Email Address]
	FROM dbo.Employees

-- Problem 7
SELECT DISTINCT [Salary]
	FROM dbo.Employees

-- Problem 8
SELECT *
	FROM dbo.Employees
	WHERE [JobTitle] = 'Sales Representative'

-- Problem 9
SELECT [FirstName], [LastName], [JobTitle]
	FROM dbo.Employees
	WHERE [Salary] >= 20000 AND [Salary] <= 30000 

-- Problem 10
SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [Full Name]
	FROM dbo.Employees
	WHERE [Salary] IN (25000, 14000, 12500, 23600)

-- Problem 11
SELECT [FirstName], [LastName]
	FROM dbo.Employees
	WHERE [ManagerID] IS NULL

-- Problem 12
SELECT [FirstName], [LastName], [Salary]
	FROM dbo.Employees
	WHERE [Salary] > 50000
	ORDER BY [Salary] DESC

-- Problem 13
SELECT TOP(5) [FirstName], [LastName]
	FROM dbo.Employees
	ORDER BY [Salary] DESC

-- Problem 14
SELECT [FirstName], [LastName]
	FROM dbo.Employees
	WHERE [DepartmentID] != 4

-- Problem 15
SELECT *
	FROM dbo.Employees
	ORDER BY [Salary] DESC, [FirstName] ASC, [LastName] DESC, [MiddleName] ASC

-- Problem 16
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName], [LastName], [Salary]
	FROM dbo.Employees

SELECT * FROM V_EmployeesSalaries

-- Problem 17
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
[FirstName] + ' ' + COALESCE(MiddleName, '') + ' ' + [LastName] AS [Full Name], [JobTitle]
	FROM dbo.Employees

-- Problem 18
SELECT DISTINCT [JobTitle]
	FROM dbo.Employees

-- Problem 19
SELECT TOP(10) *
	FROM dbo.Projects
	ORDER BY [StartDate] ASC, [Name] ASC
	
-- Problem 20
SELECT TOP(7) [FirstName], [LastName], [HireDate]
	FROM dbo.Employees
	ORDER BY [HireDate] DESC

-- Problem 21
UPDATE dbo.Employees
SET [Salary] += [Salary] * 0.12
	FROM dbo.Employees AS e JOIN dbo.Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

SELECT [Salary]
	FROM dbo.Employees