CREATE TABLE [dbo].[Reservations] (
    [reservation_id]      INT           IDENTITY (1, 1) NOT NULL,
    [customer_id]         INT           NOT NULL,
    [name]                NVARCHAR (50) NOT NULL,
    [number_of_customers] INT           NOT NULL,
    [date]                DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([reservation_id] ASC, [customer_id] ASC),
    CONSTRAINT [FK_customer_id] FOREIGN KEY ([customer_id]) REFERENCES [dbo].[Customers] ([customer_id])
);

