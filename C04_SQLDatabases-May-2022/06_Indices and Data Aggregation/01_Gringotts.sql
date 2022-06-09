USE Gringotts

-- Problem 1
SELECT COUNT(*) AS [Count]
	FROM dbo.[WizzardDeposits]

-- Problem 2
SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
	FROM dbo.[WizzardDeposits]

-- Problem 3
SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand]
	FROM dbo.[WizzardDeposits]
	GROUP BY [DepositGroup]

-- Problem 4
SELECT TOP(2) [temp].[DepositGroup]
	FROM
	(SELECT  [DepositGroup], AVG([MagicWandSize]) AS [AvgSize]
		FROM dbo.[WizzardDeposits]
		GROUP BY [DepositGroup]) AS [temp]
	ORDER BY [temp].[AvgSize] ASC

-- Problem 5
SELECT [DepositGroup], Sum([DepositAmount]) AS [TotalSum]
	FROM dbo.[WizzardDeposits]
	GROUP BY [DepositGroup]

-- Problem 6
SELECT [DepositGroup], Sum([DepositAmount]) AS [TotalSum]
	FROM dbo.[WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]

-- Problem 7
SELECT [DepositGroup], Sum([DepositAmount]) AS [TotalSum]
	FROM dbo.[WizzardDeposits]
	WHERE [MagicWandCreator] = 'Ollivander family'
	GROUP BY [DepositGroup]
	HAVING Sum([DepositAmount]) < 150000
	ORDER BY [TotalSum] DESC

-- Problem 8
SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS [MinDepositCharge]
	FROM dbo.[WizzardDeposits]
	GROUP BY [DepositGroup], [MagicWandCreator]
	ORDER BY [MagicWandCreator] ASC, [DepositGroup] ASC

-- Problem 9
SELECT [AgeGroup], COUNT(*) AS [WizardCount]
	FROM (SELECT 
		CASE 
			WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup]
		FROM dbo.[WizzardDeposits]) AS [temp]
	GROUP BY [temp].[AgeGroup]

-- Problem 10
SELECT LEFT([FirstName], 1) AS [FirstLetter]
	FROM dbo.[WizzardDeposits]
	WHERE [DepositGroup] = 'Troll Chest'
	GROUP BY LEFT([FirstName], 1)
	ORDER BY [FirstLetter] ASC

-- Problem 11
SELECT [DepositGroup], [IsDepositExpired], AVG([DepositInterest]) AS [AverageInterest]
	FROM dbo.[WizzardDeposits]
	WHERE [DepositStartDate] > '1985.01.01'
	GROUP BY [IsDepositExpired], [DepositGroup]
	ORDER BY [DepositGroup] DESC, [IsDepositExpired] ASC

-- Problem 12

