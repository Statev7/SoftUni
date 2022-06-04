USE SoftUni

-- Problem 1
SELECT [FirstName], [LastName]
	FROM dbo.Employees
	WHERE [FirstName] LIKE 'Sa%' 

-- Problem 2
SELECT [FirstName], [LastName]
	FROM dbo.Employees
	WHERE [LastName] LIKE '%ei%' 

-- Problem 3
SELECT [FirstName]
	FROM dbo.Employees
	WHERE ([DepartmentID] = 3 OR [DepartmentID] = 10) AND (YEAR([HireDate]) BETWEEN 1995 AND 2005)

-- Problem 4
SELECT [FirstName], [LastName]
	FROM dbo.Employees
	WHERE [JobTitle] NOT LIKE '%engineer%'

-- Problem 5
SELECT [Name]
	FROM dbo.Towns
	WHERE LEN([NAME]) BETWEEN 5 AND 6
	ORDER BY [Name] ASC

-- Problem 6
SELECT [TownID], [Name]
	FROM dbo.Towns
	WHERE [Name] LIKE '[MKBE]%'
	ORDER BY [Name]

-- Problem 7
SELECT [TownID], [Name]
	FROM dbo.Towns
	WHERE [Name] LIKE '[^RBD]%'
	ORDER BY [Name]

-- Problem 8
CREATE VIEW V_EmployeesHiredAfter2000 AS 
SELECT [FirstName], [LastName]
	FROM dbo.Employees
	WHERE YEAR([HireDate]) > 2000

-- Problem 9
SELECT [FirstName], [LastName]
	FROM dbo.Employees
	WHERE LEN(LastName) = 5

-- Problem 10
SELECT [EmployeeID], [FirstName], [LastName], [Salary],
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
	FROM dbo.Employees
	WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY [Salary] DESC

-- Problem 11
SELECT *
	FROM
		(SELECT [EmployeeID], [FirstName], [LastName], [Salary],
		DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
		FROM dbo.Employees
		WHERE [Salary] BETWEEN 10000 AND 50000) AS Temp
	WHERE [Rank] = 2
	ORDER BY [Salary] DESC