/*
	Выборка всех покупателей с/без заказов
*/

SELECT TOP 100
	  c.FullName
	, o.Id AS OrderId
	, o.OrderDate
	, o.TotalCost
FROM
	Customer c
	LEFT JOIN
		[Order] o ON c.Id = o.CustomerId;
