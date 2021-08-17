USE [LandSellingDB]
GO

DROP PROCEDURE IF EXISTS dbo.AddLand 
GO

CREATE PROCEDURE [dbo].AddLand
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
	,@ImageUrl nvarchar(100)
AS

	DECLARE @LotId int, @AddressId int

	
	SELECT @LotId = Id 
	FROM [dbo].[Lot] 
	WHERE
		[dbo].[Lot].OwnerId = @OwnerId 
		AND [dbo].[Lot].AddressId IN 
			(SELECT Id
			FROM [dbo].[Address]
			WHERE 
				[dbo].[Address].Country = @Country AND
				[dbo].[Address].Region = @Region AND
    			[dbo].[Address].City = @City AND
    			[dbo].[Address].Street = @Street AND
    			[dbo].[Address].Building = @Building AND
				[dbo].[Address].Latitude = @Latitude AND
				[dbo].[Address].Longitude = @Longitude)

	IF(@LotId IS NOT NULL)
	BEGIN
		PRINT('This lot is exist')
		RETURN
	END

	EXEC [dbo].[AddLot]  
			@Country
           ,@Region
           ,@City
           ,@Street
		   ,@Building
           ,@Latitude
		   ,@Longitude
		   ,@OwnerId
		   ,@Square
		   ,@Description
		   ,@ImageUrl


	SELECT @LotId = Id 
	FROM [dbo].[Lot] 
	WHERE
		[dbo].[Lot].OwnerId = @OwnerId
		AND [dbo].[Lot].AddressId IN 
			(SELECT Id
			FROM [dbo].[Address]
			WHERE 
				[dbo].[Address].Country = @Country AND
				[dbo].[Address].Region = @Region AND
    			[dbo].[Address].City = @City AND
    			[dbo].[Address].Street = @Street AND
    			[dbo].[Address].Building = @Building AND
				[dbo].[Address].Latitude = @Latitude AND
				[dbo].[Address].Longitude = @Longitude)

	INSERT INTO [dbo].[Land]
           ([LotId])
     VALUES
           (@LotId)

	RETURN @LotId
--end of AddLand prosedure


EXEC [dbo].[AddLand]  
			'Ukraine'
           ,'Lviv'
           ,'Lviv'
           ,'Lukasha'
		   ,6
           ,'49.82846685822353'
		   ,'24.014644239118265'
		   ,1
		   ,60
		   ,'description'
		   ,'https://www.planradar.com/wp-content/uploads/2020/02/Dubai.jpg'


--SELECT *
--FROM [dbo].[Address]

--SELECT *
--FROM [dbo].[AppUser]

--SELECT*
--FROM Lot

SELECT *
FROM [dbo].[vLand]

--DELETE Land
--WHERE AddressId = 1002

--DELETE Lot
--WHERE AddressId = 1002

----INSERT INTO [dbo].[Lot]
----           ([AddressId]
----           ,[PublicationDate]
----           ,[IsActive]
----           ,[Description])
----     VALUES
----           (<AddressId, int,>
----           ,<PublicationDate, date,>
----           ,<IsActive, bit,>
----           ,<Description, text,>)
----GO

----INSERT INTO [dbo].[Address]
----           ([Country]
----           ,[Region]
----           ,[City]
----           ,[Street]
----           ,[Building]
----		   ,[Latitude]
----		   ,[Longitude])
----     VALUES
----           ('Ukraine'
----           ,'Lviv'
----           ,'Lviv'
----           ,'Lukasha'
----		   ,3
----           ,'49.82846685822353'
----		   ,'24.014644239118265'
----		   )
----


--INSERT INTO [dbo].[House]
--           ([LotId]
--           ,[Rooms]
--           ,[Floor]
--           ,[Person]
--           ,[Parking]
--           ,[Furniture])
--     VALUES
--           (<LotId, int,>
--           ,<Rooms, tinyint,>
--           ,<Floor, tinyint,>
--           ,<Person, tinyint,>
--           ,<Parking, bit,>
--           ,<Furniture, bit,>)
--GO


--	SELECT Id 
--	FROM [dbo].[Lot] 
--	WHERE
--		[dbo].[Lot].OwnerId = 2
--		AND [dbo].[Lot].AddressId IN 
--			(SELECT Id
--			FROM [dbo].[Address]
--			WHERE 
--				[dbo].[Address].Country = 'Ukraine' AND
--				[dbo].[Address].Region = 'Lviv' AND
--    			[dbo].[Address].City = 'Lviv' AND
--    			[dbo].[Address].Street = 'Lukasha' AND
--    			[dbo].[Address].Building = 6)


--SELECT * 
--FROM Lot
--JOIN [dbo].[Address] ON Lot.AddressId = [dbo].[Address].Id