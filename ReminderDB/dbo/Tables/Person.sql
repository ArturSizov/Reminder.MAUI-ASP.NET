CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Position] NVARCHAR(50) NULL, 
    [Birthday] DATETIME NULL, 
    [Age] INT NULL, 
    [Days] INT NULL, 
    [Base64] TEXT NULL
)
