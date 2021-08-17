USE [LandSellingDB]
GO

DROP FUNCTION IF EXISTS dbo.CalculateTotalPrice
GO

CREATE FUNCTION dbo.CalculateTotalPrice
(
      @LotId INT,
	  @BeginDate DATE,
	  @EndDate DATE
)
RETURNS money
AS
BEGIN
    DECLARE @TotalPrice money, @PricePerDay money, @Days int

	SET @Days = DATEDIFF(DAY, @BeginDate, @EndDate)

	SELECT TOP(1) @PricePerDay = [Value]
	FROM PriceCoef
	WHERE LotId = @LotId
	  AND DaysCount > @Days
	ORDER BY DaysCount ASC

	IF(@PricePerDay IS NULL)
	BEGIN
		--PRINT 'PricePerDay is null'

		SELECT TOP(1) @PricePerDay = [Value]
		FROM PriceCoef
		WHERE LotId = @LotId
		ORDER BY DaysCount DESC
	END

	IF(@PricePerDay IS NULL)
	BEGIN
		--PRINT('PricePerDay is also null. Table don`t contain a price coef')

		SET @PricePerDay = 100
	END

	SET @TotalPrice = @PricePerDay * @Days

	RETURN @TotalPrice

END


