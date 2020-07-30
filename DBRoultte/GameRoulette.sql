CREATE TABLE [dbo].[GameRoulette]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	[UserId] int,
	[RouletteId] int,
	[BetMoney] money,
	[StartDate] datetime,
	[EndDate] datetime,
	FOREIGN KEY (UserId) REFERENCES [dbo].[Users](Id),
	FOREIGN KEY (RouletteId) REFERENCES [dbo].[Rouletts](Id)
)
