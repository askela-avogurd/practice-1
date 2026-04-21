/*
	Меняем айдишник так чтобы он соответствовал айди заказа Лены.
*/
DECLARE @LenaOrderId UNIQUEIDENTIFIER;

SELECT
	@LenaOrderId = o.Id
FROM
	[Order] o
	JOIN
		Customer c ON o.CustomerId = c.Id
	WHERE
		c.Email = 'vernik_@inbox.ru';

/*
	Поскольку он в данный момент в таблице OrderItem выглядит как Анин, заодно вычислим Анин.
*/
DECLARE @AnnaOrderId UNIQUEIDENTIFIER;

SELECT
	@AnnaOrderId = o.Id
FROM
	[Order] o
	JOIN
		Customer c ON o.CustomerId = c.Id
	WHERE
		c.Email = 'annasan@mail.ru';

SELECT TOP 100
	*
FROM
	OrderItem;

BEGIN TRANSACTION;

/*
	Там где Анин айди, но пряжа, которая в заказе Лены, должен быть Ленин айди. Картина страшная, в реальной БД так наверное делать не стоит, а пока такие изменения для ручной вставки.
*/
UPDATE
	OrderItem
SET
	OrderId = @LenaOrderId
WHERE
	YarnId = (
		SELECT
			Id
		FROM
			Yarn
		WHERE
			Name = 'Alize Lanagold Fine')
	AND
	OrderId = @AnnaOrderId;
	
SELECT TOP 100
	*
FROM
	OrderItem;

COMMIT TRANSACTION;

-- ROLLBACK TRANSACTION;