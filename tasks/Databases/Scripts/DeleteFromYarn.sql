/*
	Удаление записей с ценником менее 250 рублей из таблицы Yarn.
*/

SELECT TOP 100
	*
FROM
	Yarn
WHERE
	PricePer100g < 250.00;


BEGIN TRANSACTION;

DELETE
	FROM
		Yarn
	WHERE
		PricePer100g < 250.00;

SELECT TOP 100
	*
FROM
	Yarn
WHERE
	PricePer100g < 250.00;

ROLLBACK TRANSACTION;

SELECT TOP 100
	*
FROM
	Yarn
WHERE
	PricePer100g < 250.00;
