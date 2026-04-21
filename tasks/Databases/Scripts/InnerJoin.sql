/*
	Пряжа, которую заказывали хоть раз
*/

SELECT DISTINCT TOP 100
	  y.Name
	, y.PricePer100g
FROM
	Yarn y
	INNER JOIN
		OrderItem oi ON y.Id = oi.YarnId;