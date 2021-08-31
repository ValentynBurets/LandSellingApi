USE [LandSellingDB]
GO

DROP PROCEDURE IF EXISTS dbo.AddLot 
GO

CREATE PROCEDURE [dbo].AddLot 
	--Address Data
	 @Country nvarchar(100)
    ,@Region  nvarchar(100)
    ,@City  nvarchar(100)
    ,@Street  nvarchar(100)
    ,@Building  nvarchar(100)
	,@Latitude  nvarchar(100)
	,@Longitude  nvarchar(100)
	,@OwnerId int
	,@Square real
	,@Description text

AS

	DECLARE @AddressId int, @res bit

	SELECT @AddressId = Id FROM [dbo].[Address] 
						   WHERE
							[dbo].[Address].Country = @Country AND
							[dbo].[Address].Region = @Region AND
    						[dbo].[Address].City = @City AND
    						[dbo].[Address].Street = @Street AND
    						[dbo].[Address].Building = @Building AND
							[dbo].[Address].Latitude = @Latitude AND
							[dbo].[Address].Longitude = @Longitude
	
	PRINT(@AddressId)

	IF(@AddressId IS NULL)
	BEGIN
		INSERT INTO [dbo].[Address]
           ([Country]
           ,[Region]
           ,[City]
           ,[Street]
           ,[Building]
		   ,[Latitude]
		   ,[Longitude])
		VALUES
           (@Country
           ,@Region
           ,@City
           ,@Street
		   ,@Building
           ,@Latitude
		   ,@Longitude
		   )
		PRINT('Inserted new value in address table')

		SELECT @AddressId = Id FROM [dbo].[Address] 
						   WHERE
							[dbo].[Address].Country = @Country AND
							[dbo].[Address].Region = @Region AND
    						[dbo].[Address].City = @City AND
    						[dbo].[Address].Street = @Street AND
    						[dbo].[Address].Building = @Building AND
							[dbo].[Address].Latitude = @Latitude AND
							[dbo].[Address].Longitude = @Longitude
	END
	
	DECLARE @LotId int

	SELECT @LotId = Id
	FROM [dbo].[Lot]
	WHERE [dbo].[Lot].AddressId = @AddressId

	--IF(@LotId IS NOT NULL)
	--BEGIN
	--	PRINT('This Lot is exist. A new lot would not be inserted')
	--	RETURN 
	--END

	DECLARE @DateNow DATE, @LotStatusId INT
	SET @DateNow = CAST( GETDATE() AS Date)
	SELECT @LotStatusId = Id FROM [dbo].[LotStatusType] 
							 WHERE [dbo].[LotStatusType].[Name] = 'Available'
	
	INSERT INTO [dbo].[Lot]
           ([AddressId]
           ,[PublicationDate]
           ,[LotStatusId]
		   ,[OwnerId]
		   ,[Square]
           ,[Description])
     VALUES
           (@AddressId
		   ,@DateNow
           ,@LotStatusId
		   ,@OwnerId
		   ,@Square
           ,@Description)

	PRINT('Inserted new value in Lot table')
--end of AddLot prosedure


EXEC [dbo].[AddLot]  
			'Ukraine'
           ,'Rivne Region'
           ,'Demydivka'
           ,'molodigna'
		   ,0
           ,'50.41851443436447'
		   ,'25.36874770423823'
		   ,1
		   ,100
		   ,'land for selling'
		   
SELECT *
FROM [dbo].[Lot]

SELECT *
FROM [dbo].[Address]

SELECT *
FROM [dbo].[AppUser]



--INSERT INTO [dbo].[Lot]
--           ([AddressId]
--           ,[PublicationDate]
--           ,[IsActive]
--           ,[Description])
--     VALUES
--           (<AddressId, int,>
--           ,<PublicationDate, date,>
--           ,<IsActive, bit,>
--           ,<Description, text,>)
--GO

--INSERT INTO [dbo].[Address]
--           ([Country]
--           ,[Region]
--           ,[City]
--           ,[Street]
--           ,[Building]
--		   ,[Latitude]
--		   ,[Longitude])
--     VALUES
--           ('Ukraine'
--           ,'Lviv'
--           ,'Lviv'
--           ,'Lukasha'
--		   ,3
--           ,'49.82846685822353'
--		   ,'24.014644239118265'
--		   )
--