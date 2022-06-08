USE [Geography]

-- Problem 12
SELECT co.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation]
	FROM dbo.[Countries] AS co
	JOIN dbo.[MountainsCountries] AS mc ON co.[CountryCode] = mc.[CountryCode]
	JOIN dbo.[Mountains] AS m ON mc.[MountainId] = m.[Id]
	JOIN dbo.[Peaks] AS p ON p.[MountainId] = m.[Id]
	WHERE co.[CountryName] = 'Bulgaria' AND p.[Elevation] > 2835
	ORDER BY p.[Elevation] DESC

-- Problem 13
SELECT c.[CountryCode], COUNT(m.MountainRange) AS [MountainRanges]
	FROM dbo.[Countries] AS c
	JOIN dbo.[MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	JOIN dbo.[Mountains] AS m ON mc.[MountainId] = m.[Id]
	WHERE c.[CountryName] IN ('United States', 'Russia', 'Bulgaria')
	GROUP BY c.[CountryCode]

-- Problem 14
SELECT TOP(5) c.[CountryName], r.[RiverName]
	FROM dbo.[Countries] AS c
	LEFT JOIN dbo.[CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
	LEFT JOIN dbo.[Rivers] AS r ON cr.[RiverId] = r.[Id]
	JOIN dbo.[Continents] AS con ON c.[ContinentCode] = con.[ContinentCode]
	WHERE con.[ContinentName] = 'Africa'
	ORDER BY c.[CountryName] ASC

-- Problem 15
 SELECT [ContinentCode],
        [CurrencyCode],
        [CurrencyUsage]
   FROM (
         SELECT *,
                DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC)
             AS [CurrencyRank]
           FROM (
                    SELECT [co].[ContinentCode],
                           [c].[CurrencyCode],
                           COUNT([c].[CurrencyCode]) AS [CurrencyUsage]
                      FROM [Continents] AS [co]
                 LEFT JOIN [Countries] AS [c]
                        ON [c].[ContinentCode] = [co].[ContinentCode]
                  GROUP BY [co].[ContinentCode], [c].[CurrencyCode]
                ) AS [CurrencyUsageQuery]
          WHERE [CurrencyUsage] > 1
         ) AS [CurrencyRankingQuery]
   WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]

-- Problem 16
SELECT COUNT(c.[CountryName]) AS [Count]
	FROM dbo.[Countries] AS c
	LEFT JOIN dbo.[MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	LEFT JOIN dbo.[Mountains] AS m ON mc.[MountainId] = m.[Id]
	WHERE m.Id IS NULL
	GROUP BY m.MountainRange

-- Problem 17
SELECT TOP(5) c.[CountryName], MAX(p.[Elevation]) AS HighestPeakElavation, MAX(r.[Length]) AS LongestRiverLength
	FROM dbo.[Countries] AS c
	JOIN dbo.[MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
	JOIN dbo.[Mountains] AS m ON mc.[MountainId] = m.[Id]
	JOIN dbo.[Peaks] AS p ON m.[Id] = p.[MountainId]
	JOIN dbo.[CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
	JOIN dbo.[Rivers] AS r ON cr.[RiverId] = r.[Id]
	GROUP BY c.[CountryName]
	ORDER BY HighestPeakElavation DESC, LongestRiverLength DESC, c.[CountryName] ASC

-- Problem 18

SELECT TOP(5) [temp].[CountryName],
	CASE
		WHEN [temp].[PeakName] IS NULL THEN '(no highest peak)'
		ELSE [temp].[PeakName]
	END AS [Highest Peak Name],
	CASE 
		WHEN [temp].[Elevation] IS NULL THEN 0
		ELSE [temp].[Elevation]
	END AS [Highest Peak Elevation],
	CASE
		WHEN [temp].[MountainRange] IS NULL THEN '(no mountain)'
		ELSE [temp].[MountainRange]
	END AS [Mountain]
		FROM (SELECT [c].[CountryName], [p].[PeakName], [p].[Elevation], [m].[MountainRange],
				DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC)
				AS [Rank]
				FROM dbo.[Countries] AS [c]
				LEFT JOIN dbo.[MountainsCountries] AS [mc] ON [c].[CountryCode] = [mc].[CountryCode]
				LEFT JOIN dbo.[Mountains] AS [m] ON [mc].[MountainId] = [m].[Id]
				LEFT JOIN dbo.[Peaks] AS [p] ON [m].[Id] = [p].[MountainId]
				)AS [temp]
		WHERE [Rank] = 1
		ORDER BY [temp].[CountryName] ASC, [Highest Peak Elevation] DESC
