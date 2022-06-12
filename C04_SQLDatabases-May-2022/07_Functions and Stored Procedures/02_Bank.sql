USE Bank

-- Problem 9
CREATE PROCEDURE usp_GetHoldersFullName 
AS	
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
		FROM dbo.[AccountHolders]

-- Problem 10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@money MONEY)
AS
	SELECT [temp].[FirstName], [temp].[LastName]
		FROM	
		(SELECT ah.[FirstName], ah.[LastName], SUM(a.[Balance]) AS [Balance]
			FROM dbo.[AccountHolders] AS ah
			JOIN dbo.[Accounts] AS a ON ah.Id = a.AccountHolderId
			GROUP BY a.[AccountHolderId], ah.[FirstName], ah.[LastName]) AS [temp]
		WHERE [temp].[Balance] > @money
		ORDER BY [temp].[FirstName] ASC, [temp].[LastName] ASC

-- Problem 11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18, 2), @yearlyRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	RETURN @sum * (POWER(1 + @yearlyRate, @numberOfYears))
END

-- Problem 12
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountId INT, @yearlyRate FLOAT)
AS
	SELECT [a].[Id], 
			[ah].[FirstName], [ah].[LastName], 
			[a].[Balance] AS [Current Balance], 
			dbo.ufn_CalculateFutureValue(a.[Balance], @yearlyRate, 5) AS [Balance in 5 years]
		FROM dbo.[AccountHolders] AS [ah]
		JOIN dbo.[Accounts] AS [a] ON [ah].[Id] = [a].[AccountHolderId]
		WHERE [a].[Id] = @accountId

-- Problem 13
USE Diablo

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(64))
RETURNS @result TABLE(
	[SumCash] MONEY
) AS
BEGIN
	INSERT INTO @result SELECT SUM([Cash]) AS [SumCash]
							FROM (SELECT [g].[Name], [ug].[Cash],
								ROW_NUMBER() OVER (PARTITION BY [g].[Name] ORDER BY [ug].[Cash] DESC) AS [RowNumber]
								FROM dbo.[Games] AS [g]
								JOIN dbo.[UsersGames] AS [ug] ON [g].[Id] = [ug].[GameId]
								WHERE [g].[Name] = @gameName) AS [temp]
							WHERE [temp].[RowNumber] % 2 <> 0
							GROUP BY [temp].[Name]
	RETURN
END


