USE YarnStore;
GO

INSERT INTO Yarn(Name, PricePer100g, StockQuantity, IsInStock, BrandId, CategoryId) VALUES
('Super Acrylic', 350.00, 50, 1, ISNULL((SELECT TOP 1 Id FROM Brand WHERE Name LIKE '%Lana Grossa%'), 0), (ISNULL((SELECT TOP 1 Id FROM Category WHERE TypeName LIKE '%Acrylic%'), 0))),
('Drops Baby Merino', 290.00, 90, 1, ISNULL((SELECT TOP 1 Id FROM Brand WHERE Name LIKE '%Drops%') ,0), (ISNULL((SELECT TOP 1 Id FROM Category WHERE TypeName LIKE '%Merino Wool%'), 0))),
('Alize Cotton Gold', 220.00, 100, 1, ISNULL((SELECT TOP 1 Id FROM Brand WHERE Name LIKE '%Alize%'), 0), (ISNULL((SELECT TOP 1 Id FROM Category WHERE TypeName LIKE '%Cotton%'), 0))),
('Alize Lanagold Fine', 310.00, 75, 1, ISNULL((SELECT TOP 1 Id FROM Brand WHERE Name LIKE '%Alize%'), 0), (ISNULL((SELECT TOP 1 Id FROM Category WHERE TypeName LIKE '%Sheep Wool%'), 0)));