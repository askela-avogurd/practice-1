-- Выборка пряжи дороже 250 рублей в продаже в порядке убывания.

SELECT Name, PricePer100g, StockQuantity
FROM Yarn
WHERE IsInStock=1 AND PricePer100g > 250.00
ORDER BY PricePer100g DESC