CREATE TABLE [dbo].[Order_items] (
    [order_item_id] INT            IDENTITY (1, 1) NOT NULL,
    [customer_id]   INT            NOT NULL,
    [order_id]      INT            NOT NULL,
    [item_id]       INT            NOT NULL,
    [quantity]      INT            NOT NULL,
    [desctiption]   NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([order_item_id] ASC, [customer_id] ASC, [order_id] ASC, [item_id] ASC),
    CONSTRAINT [FK_order_id] FOREIGN KEY ([order_id], [customer_id]) REFERENCES [dbo].[Orders] ([order_id], [customer_id]),
    CONSTRAINT [FK_item_id] FOREIGN KEY ([item_id]) REFERENCES [dbo].[Items] ([item_id])
);

