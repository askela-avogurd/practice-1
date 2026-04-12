-- Выборка всех покупателей с/без заказов

SELECT c.FullName, o.Id AS OrderId, o.OrderDate, o.TotalCost
FROM Customer c
LEFT JOIN [Order] o ON c.Id = o.CustomerId;