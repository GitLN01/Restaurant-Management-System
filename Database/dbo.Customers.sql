CREATE TABLE [dbo].[Customers]
(
	[customer_id] INT IDENTITY (1, 1) NOT NULL, 
    [name] NVARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [contact] NVARCHAR(50) NOT NULL
	PRIMARY KEY CLUSTERED ([customer_id] ASC)
)
