CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Email] VARCHAR(320) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NOT NULL, 
    [Adress] NVARCHAR(100) NOT NULL, 
    [City] NVARCHAR(66) NOT NULL, 
    [Neto] DECIMAL(13, 6) NOT NULL, 
    [Bruto] DECIMAL(13, 6) NOT NULL
)
