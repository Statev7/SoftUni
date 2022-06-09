USE [SoftUni]

-- Problem 13
SELECT [DepartmentID], SUM([Salary]) AS TotalSalary
	FROM dbo.[Employees]
	GROUP BY [DepartmentID]
	ORDER BY [DepartmentID]

-- Problem 14
SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary]
	FROM dbo.[Employees]
	WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '2000.01.01'
	GROUP BY [DepartmentID]

-- Problem 15
SELECT * 
	INTO TempTable 
		FROM dbo.Employees 
		WHERE Salary > 30000

DELETE TempTable
WHERE ManagerID = 42

UPDATE TempTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT [DepartmentID], AVG([Salary]) AS AverageSalary
	FROM dbo.TempTable
	GROUP BY [DepartmentID]

-- Problem 16
SELECT [DepartmentID], MAX([Salary]) AS MaxSalary
	FROM dbo.Employees
	GROUP BY [DepartmentID]
	HAVING MAX([Salary]) < 30000 OR MAX([Salary]) > 70000

-- Problem 17
SELECT COUNT(*) AS [Count]
	FROM dbo.[Employees]
	WHERE ManagerID IS NULL

-- Problem 18
SELECT DISTINCT [temp].DepartmentID, [temp].[ThirdHighestSalary]
	FROM
	(
		SELECT [DepartmentID], [Salary] AS [ThirdHighestSalary],
		DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
		FROM dbo.[Employees]
	) AS [temp]
	WHERE [Rank] = 3

-- Problem 19
SELECT TOP(10) [e].[FirstName], [e].[LastName], [e].[DepartmentID]
	FROM dbo.[Employees] AS [e]
	WHERE [e].[Salary] > (SELECT AVG([em].Salary) 
							FROM dbo.[Employees] AS [em] 
							WHERE [em].[DepartmentID] = [e].[DepartmentID]) 
	
