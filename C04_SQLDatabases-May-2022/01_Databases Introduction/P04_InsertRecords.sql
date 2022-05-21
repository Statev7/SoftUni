/*Problem 1 */
CREATE DATABASE Minions

/*Problem 2 */

CREATE TABLE Minions 
(
	Id INT NOT NULL,
	[Name] VARCHAR(50) NOT NULL	,
	AGE INT
)

CREATE TABLE Towns
(
	Id INT NOT NULL,
	[NAME] VARCHAR(50) NOT NULL
)

ALTER TABLE Minions
ADD PRIMARY KEY (Id)

ALTER TABLE Towns
ADD PRIMARY KEY (Id)

/* Problem 3 */

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionsTown
FOREIGN KEY (TownId) REFERENCES Towns(Id);

/* Problem 4 */

INSERT INTO Towns(Id, [NAME])
VALUES 
	(1, 'Sofia'), 
	(2, 'Plovdiv'), 
	(3, 'Varna');

INSERT INTO dbo.Minions(Id, [Name], AGE, TownId)
VALUES 
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2);

/* Problem 5 */

TRUNCATE TABLE dbo.Minions;

/* Problem 6 */

DROP TABLE dbo.Minions
