USE YarnStore;
GO

INSERT INTO [Order](CustomerId, TotalCost) VALUES
((SELECT TOP 1 Id FROM Customer WHERE Email='annasan@mail.ru'), 700.00),
((SELECT TOP 1 Id FROM Customer WHERE Email='vernik_@inbox.ru'), 310.00);