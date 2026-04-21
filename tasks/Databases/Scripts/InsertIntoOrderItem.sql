USE YarnStore;
GO

INSERT INTO OrderItem(OrderId, YarnId, Quantity, PriceAtPurchase) VALUES
((SELECT TOP 1 Id FROM [Order]), (SELECT TOP 1 Id FROM Yarn WHERE Name='Super Acrylic'), 2, (SELECT TOP 1 PricePer100g FROM Yarn WHERE Name='Super Acrylic')),
((SELECT TOP 1 Id FROM [Order]), (SELECT TOP 1 Id FROM Yarn WHERE Name='Alize Lanagold Fine'), 1, (SELECT TOP 1 PricePer100g FROM Yarn WHERE Name='Alize Lanagold Fine'));