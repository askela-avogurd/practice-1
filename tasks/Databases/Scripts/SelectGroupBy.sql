/*
	Выборка с группировкой по бренду (суммы продаж по брендам)
*/

SELECT TOP 100
	  b.Name AS BrandName
	, SUM(oi.Quantity * oi.PriceAtPurchase) AS TotalSales
FROM
	OrderItem oi
	JOIN
		Yarn y ON oi.YarnId = y.Id
	JOIN
		Brand b ON y.BrandId = b.Id
GROUP BY
	b.Name;