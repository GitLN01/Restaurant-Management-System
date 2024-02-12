CREATE TABLE [dbo].[Orders] (
    [order_id]     INT      IDENTITY (1, 1) NOT NULL,
    [customer_id]  INT      NOT NULL,
    [time]         DATETIME NOT NULL,
    [table_number] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([order_id] ASC, [customer_id] ASC),
    CONSTRAINT [FK_customer_id1] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customers] ([customer_id])
);

