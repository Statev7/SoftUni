USE Geography

-- Problem 12
SELECT [CountryName], [IsoCode]
	FROM dbo.Countries
	WHERE [CountryName] LIKE '%a%a%a%'
	ORDER BY [IsoCode] ASC

-- Problem 13
SELECT p.[PeakName], rn.[RiverName], LOWER(CONCAT(SUBSTRING(PeakName, 1, LEN(PeakName) - 1), rn.RiverName)) AS Mix
	FROM dbo.Peaks AS p,
		(Select [RiverName] FROM dbo.Rivers) AS rn
	WHERE RIGHT(p.[PeakName], 1) = LEFT(rn.[RiverName], 1)
	ORDER BY Mix ASC
	
