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

CREATE TABLE Fields(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	FieldName NVARCHAR(20) NOT NULL
)

CREATE TABLE FieldReservations(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Member1Id INT NOT NULL FOREIGN KEY REFERENCES Members(Id),
	Member2Id INT NOT NULL FOREIGN KEY REFERENCES Members(Id),
	FieldId INT NOT NULL FOREIGN KEY REFERENCES Fields(Id), 
	ReservationTime SMALLDATETIME NOT NULL
)


INSERT INTO Members VALUES ('Frida Mortensen', 'Hans Schacksvej 6 2740 Skovlunde', '22180700', 'FridaAMortensen@armyspy.com', '1994-10-17', 1, 2, 2)
INSERT INTO Members VALUES ('Nicolai Nygaard', 'Muusg�rden 16 9300 S�by', '52886204', 'NicolaiNNygaard@armyspy.com', '1938-3-24', 0, 1, 5)

INSERT INTO Fields VALUES ('Bane 1')
INSERT INTO Fields VALUES ('Bane 2')
INSERT INTO Fields VALUES ('Bane 3')
INSERT INTO Fields VALUES ('Bane 4')

INSERT INTO FieldReservations VALUES (1, 2, 1, '2020-03-11 14:00:00')