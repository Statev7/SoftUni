CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK (DATALENGTH(ProfilePicture) < 900),
	LastLoginTime DATE NOT NULL,
	IsDeleted BIT NOT NULL  
);

INSERT INTO dbo.Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
	('Pesho1', '323232', '2022-05-21', 0),
	('Pesho2', '323232', '2002-05-13', 1),
	('Pesho3', '323232', '2021-05-21', 1),
	('Pesho4', '323232', '2022-05-12', 0),
	('Pesho5', '323232', '2022-05-18', 0)

/* Problem 9 */

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0721763720;

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY (Id, Username)

/* Problem 10 */

ALTER TABLE Users
ADD CONSTRAINT Check_PasswordLenght
CHECK (LEN([Password]) >= 5)

/* Problem 11 */

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;

/* Problem 12 */

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername