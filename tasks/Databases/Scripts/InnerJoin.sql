-- Пряжа, которую заказывали хоть раз

SELECT DISTINCT y.Name, y.PricePer100g
FROM Yarn y
INNER JOIN OrderItem oi ON y.Id = oi.YarnId;