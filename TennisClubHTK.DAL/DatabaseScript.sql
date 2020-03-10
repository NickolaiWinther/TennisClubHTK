USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='TennisClubHTK')
DROP DATABASE TennisClubHTK

CREATE DATABASE TennisClubHTK
GO

USE TennisClubHTK

CREATE TABLE Members(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(50) NOT NULL,
	Address NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	BirthDate DATE NOT NULL,
	Active BIT NOT NULL,
	Gender INT NOT NULL,
	AgeGroup INT NOT NULL
)

INSERT INTO Members VALUES ('Frida Mortensen', 'Hans Schacksvej 6 2740 Skovlunde', '22180700', 'FridaAMortensen@armyspy.com', '1994-10-17', 1, 2, 2)
INSERT INTO Members VALUES ('Nickolai Nygaard', 'Muusgården 16 9300 Sæby', '52886204', 'NicolaiNNygaard@armyspy.com', '1938-3-24', 0, 1, 5)