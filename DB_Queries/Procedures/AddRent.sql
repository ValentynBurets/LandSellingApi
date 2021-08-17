USE [LandSellingDB]
GO

DROP PROCEDURE IF EXISTS dbo.AddRent 
GO

CREATE PROCEDURE [dbo].AddRent
	 @LotId int
    ,@CustomerId int
    ,@ManagerId int
    ,@BeginDate date
    ,@EndDate date
    ,@Price money
AS
	DECLARE @Res int

	SELECT @Res = Id
	FROM Rent
	WHERE LotId = @LotId 
		  AND CustomerId = @CustomerId 
		  AND ManagerId = @ManagerId 
		  AND BeginDate = @BeginDate 
		  AND EndDate = @EndDate 
		  AND Price = @Price

	IF(@Res IS NOT NULL)
	BEGIN 
		PRINT('This position is exist')
		RETURN
	END
	
	SELECT @Res = Id
	FROM Rent
	WHERE LotId = @LotId 
		  AND CustomerId = @CustomerId 
		  AND ManagerId = @ManagerId 
		  
	--calculate price

	SELECT @Price = [dbo].[CalculateTotalPrice] (
	@LotId
	,@BeginDate
	,@EndDate)

	--set @pass=dbo.function_to_be_called(@user) 

	PRINT(dbo.CalculateTotalPrice(@LotId, @BeginDate, @EndDate))

	IF(@Res IS NOT NULL)
	BEGIN 
		PRINT('This position is exist but we should update this position')

		UPDATE Rent
		SET  BeginDate = @BeginDate 
		     ,EndDate = @EndDate 
		     ,Price = @Price

		RETURN
	END

	PRINT('This position isn`t exist in table, we should insert this new position')

	DECLARE @RentStatusId int

	SELECT @RentStatusId = Id
	FROM RentStatusType
	WHERE [Name] = 'Created'

	INSERT INTO [dbo].[Rent]
           ([LotId]
           ,[RentStatusId]
           ,[CustomerId]
           ,[ManagerId]
           ,[BeginDate]
           ,[EndDate]
           ,[Price])
     VALUES
           (@LotId
           ,@RentStatusId
           ,@CustomerId
           ,@ManagerId
           ,@BeginDate
           ,@EndDate
           ,@Price)

--end of AddRent prosedure
