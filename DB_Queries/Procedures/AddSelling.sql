USE [LandSellingDB]
GO

DROP PROCEDURE IF EXISTS dbo.AddSelling 
GO

CREATE PROCEDURE [dbo].AddSelling
	 @LotId int
    ,@ManagerId int
    ,@MinPrice money
    ,@PriceBuyItNow money
AS
	DECLARE @Res int

	SELECT @Res = Id
	FROM Selling
	WHERE LotId = @LotId AND ManagerId = @ManagerId AND MinPrice = @MinPrice AND PriceBuyItNow = @PriceBuyItNow

	IF(@Res IS NOT NULL)
	BEGIN 
		PRINT('This position is exist')
		RETURN
	END

	SELECT @Res = Id
	FROM Selling
	WHERE LotId = @LotId AND ManagerId = @ManagerId

	IF(@Res IS NOT NULL)
	BEGIN 
		PRINT('This position is exist but we should update this position')

		UPDATE Selling
		SET MinPrice = @MinPrice
			,PriceBuyItNow = @PriceBuyItNow

		RETURN
	END

	PRINT('This position isn`t exist in table, we should insert this new position')

	DECLARE @SellingStatusId int

	SELECT @SellingStatusId = Id
	FROM SellingStatusType
	WHERE [Name] = 'Created'

	SELECT * FROM SellingStatusType
	
	INSERT INTO [dbo].[Selling]
           ([LotId]
           ,[ManagerId]
           ,[SellingStatusId]
           ,[MinPrice]
           ,[PriceBuyItNow])
     VALUES
           (@LotId
           ,@ManagerId
           ,@SellingStatusId
           ,@MinPrice
           ,@PriceBuyItNow)

--end of AddLand prosedure

-- TODO: Set parameter values here.

EXECUTE [dbo].[AddSelling] 
   3
  ,4
  ,100
  ,300
GO


SELECT * FROM Selling
