USE [SoftUni]

-- Problem 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
	SELECT [FirstName], [LastName]
		FROM dbo.[Employees]
		WHERE [Salary] > 35000

-- Problem 2
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18, 4))
AS
	SELECT [FirstName], [LastName]
		FROM dbo.[Employees]
		WHERE [Salary] >= @Number

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- Problem 3
CREATE PROCEDURE usp_GetTownsStartingWith(@Argument VARCHAR(8))
AS
	SELECT [Name]
		FROM dbo.[Towns]
		WHERE [Name] LIKE @Argument + '%'

EXEC usp_GetTownsStartingWith 'b'

-- Problem 4
CREATE PROCEDURE usp_GetEmployeesFromTown(@TownName VARCHAR(32))
AS
	SELECT [e].[FirstName], [e].[LastName]
		FROM dbo.[Employees] AS [e]
		JOIN dbo.[Addresses] AS [a] ON [e].[AddressID] = [a].[AddressID]
		JOIN dbo.[Towns] AS [t] ON [a].[TownID] = [t].[TownID]
		WHERE [t].[Name] = @TownName

EXEC usp_GetEmployeesFromTown 'Sofia'

-- Problem 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(32)
AS
BEGIN
	DECLARE @result VARCHAR(32);

	IF(@salary < 30000)
		SET @result = 'Low';
	ELSE IF(@salary <= 50000)
		SET @result = 'Average'
	ELSE SET @result = 'High'

	RETURN @result;
END

SELECT [Salary], dbo.[ufn_GetSalaryLevel]([Salary]) AS [Salary Level]
FROM dbo.[Employees]

-- Problem 6
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevelAsString VARCHAR(32))
AS
	SELECT [FirstName], [LastName]
		FROM dbo.[Employees]
		WHERE dbo.[ufn_GetSalaryLevel]([Salary]) = @salaryLevelAsString

EXEC usp_EmployeesBySalaryLevel 'high'

-- Problem 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(32), @word VARCHAR(32))
RETURNS BIT
BEGIN
	DECLARE @count INT = LEN(@word);
	DECLARE @index INT = 1;

	WHILE(@index <= @count)
	BEGIN
		DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @index, 1);

		DECLARE @indexOf INT = CHARINDEX(@currentLetter, @setOfLetters);
		IF(@indexOf <= 0)
			RETURN 0;
		
		SET @index += 1;
	END
	RETURN 1;
END

SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')

-- Problem 8
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId INT) 
AS
	ALTER TABLE dbo.[Departments] ALTER COLUMN [ManagerID] INT

	DELETE
		FROM dbo.[EmployeesProjects]
		WHERE [EmployeesProjects].[EmployeeID] IN (SELECT [e].[EmployeeID]
												FROM [Employees] AS [e]
												WHERE [e].[DepartmentID] = @departmentId);
	 UPDATE dbo.[Employees]
	    SET [Employees].[ManagerID] = NULL
		WHERE [Employees].[ManagerID] IN (SELECT [e].[EmployeeID]
										FROM [Employees] AS [e]
										WHERE [e].[DepartmentID] = @departmentId);

	UPDATE dbo.[Departments] 
		SET [ManagerID] = NULL
		WHERE [DepartmentID] = @departmentId

	DELETE FROM dbo.[Employees] 
		WHERE [DepartmentID] = @departmentId;

	DELETE FROM dbo.[Departments] 
		WHERE [DepartmentID] = @departmentId

	SELECT COUNT(*)
		FROM dbo.[Employees]
		WHERE [DepartmentID] = @departmentId

