USE Diablo

-- Problem 14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS Start
	FROM dbo.Games
	WHERE YEAR([Start]) BETWEEN 2011 AND 2012
	ORDER BY [Start] ASC, [Name] ASC

--Problem 15
SELECT [Username], SUBSTRING([Email],  CHARINDEX('@', [Email]) + 1, LEN([Email])) AS [Email Provider]
	FROM dbo.Users
	ORDER BY [Email Provider] ASC, [UserName] ASC

-- Problem 16
SELECT [UserName], [IpAddress]
	FROM dbo.Users
	WHERE [IpAddress] LIKE '[0-9][0-9][0-9].1%.%.[0-9][0-9][0-9]' 
	ORDER BY [UserName]

-- Problem 17
SELECT [Name],
	(CASE 
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END) AS [Part of the Day],
	(CASE 
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
		END) AS [DurationResult]
	FROM dbo.Games
	ORDER BY [Name] ASC, [DurationResult] ASC, [Part of the Day] ASC


