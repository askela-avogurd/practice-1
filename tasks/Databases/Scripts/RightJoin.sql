/*
	Все заказы и данные покупателей
*/

SELECT TOP 100
	  o.[Id] AS OrderId
	, c.FullName
	, o.TotalCost
FROM
	Customer c
	RIGHT JOIN
		[Order] o ON c.Id = o.CustomerId;
