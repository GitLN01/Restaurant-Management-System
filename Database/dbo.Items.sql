CREATE TABLE [dbo].[Items]
(
	[item_id] INT IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR(50) NOT NULL, 
    [price] DECIMAL(18, 2) NOT NULL, 
    [category] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED ([item_id] ASC)
)
