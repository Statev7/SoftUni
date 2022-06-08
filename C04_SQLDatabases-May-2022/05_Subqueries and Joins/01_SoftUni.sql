USE [SoftUni]

-- Problem 1
SELECT TOP(5) e.[EmployeeID], e.[JobTitle], e.[AddressID], a.[AddressText]
	FROM dbo.[Employees] AS e
	JOIN dbo.[Addresses] AS a ON e.AddressID = a.AddressID
	ORDER BY e.[AddressID] ASC

-- Problem 2

SELECT TOP(50) e.[FirstName], e.[LastName], t.[Name], a.[AddressText]
	FROM dbo.[Employees] AS e
	JOIN dbo.[Addresses] AS a ON e.[AddressID] = a.[AddressID]
	JOIN dbo.[Towns] AS t ON a.[TownID] = t.[TownID]
	ORDER BY e.[FirstName], e.[LastName], t.[Name], a.[AddressText]

-- Problem 3

SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name]
	FROM dbo.[Employees] AS e
	JOIN dbo.[Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE d.[Name] = 'Sales'
	ORDER BY e.[EmployeeID] ASC

-- Problem 4

SELECT TOP(5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name]
	FROM dbo.[Employees] AS e
	JOIN dbo.[Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE e.[Salary] > 15000
	ORDER BY d.[DepartmentID] ASC

-- Problem 5

SELECT TOP(3) e.[EmployeeID], e.[FirstName]
	FROM dbo.[Employees] AS e
	LEFT JOIN dbo.[EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	LEFT JOIN dbo.[Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
	WHERE p.[Name] IS NULL
	ORDER BY e.[EmployeeID] ASC

-- Problem 6

SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS DeptName
	FROM dbo.[Employees] AS e
	JOIN dbo.[Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
	WHERE e.[HireDate] > '1.1.1999' AND (d.[Name] IN ('Sales', 'Finance'))
	ORDER BY e.[HireDate] ASC

-- Problem 7

SELECT TOP(5) e.[EmployeeID], e.[FirstName], p.[Name]
	FROM dbo.[Employees] AS e
	JOIN dbo.[EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN dbo.[Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
	WHERE p.[StartDate] > 13/08/2002 AND p.[EndDate] IS NULL
	ORDER BY e.[EmployeeID] ASC

-- Problem 8

SELECT e.[EmployeeID], e.[FirstName], IIF(p.StartDate <= '01/01/2005', p.[Name], NULL) AS ProjectName
	FROM dbo.Employees AS e
	JOIN dbo.[EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	JOIN dbo.[Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
	WHERE e.[EmployeeID] = 24

-- Problem 9
SELECT e.EmployeeID, e.FirstName, m.EmployeeID, m.FirstName
	FROM dbo.Employees AS e
	JOIN dbo.Employees AS m ON e.ManagerID = m.EmployeeID
	WHERE e.ManagerID IN (3,7)
	ORDER BY e.EmployeeID

-- Problem 10

SELECT TOP(50) e.[EmployeeID], 
	CONCAT(e.[FirstName],' ', e.[LastName]) AS [EmployeeName], 
	CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName],
	d.[Name]
		FROM dbo.[Employees] AS e
		JOIN dbo.[Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
		JOIN dbo.[Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
		ORDER BY e.[EmployeeID]

-- Problem 11
SELECT TOP(1) AVG(e.[Salary]) AS [MinAverageSalary]
	FROM dbo.[Employees] AS e
	JOIN dbo.[Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
	GROUP BY d.[Name]
	ORDER BY [MinAverageSalary] ASC

