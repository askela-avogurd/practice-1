/*
	Скидка 20% на любую шерстяную пряжу (в наличии мериносовая и овечья)
*/

UPDATE
	Yarn
SET
	PricePer100g = PricePer100g * 0.8
WHERE
	CategoryId IN (
		SELECT
			Id
		FROM
			Category
		WHERE
			TypeName LIKE '%Wool');
