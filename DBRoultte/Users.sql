CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	[Name] varchar(80),
	[Alias] varchar(30),
	[Money] money,
	[Status] bit
)
