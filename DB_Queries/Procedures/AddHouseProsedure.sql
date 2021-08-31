USE [LandSellingDB]
GO

DROP PROCEDURE IF EXISTS dbo.AddHouse 
GO

CREATE PROCEDURE [dbo].AddHouse 
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
	,@Rooms int
    ,@Storeys int
    ,@Person int
    ,@Parking bit
    ,@Furniture bit
AS

	DECLARE @LotId int, @res bit

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

	--IF(@HouseId IS NOT NULL)
	--BEGIN
	--	PRINT('This Lot is exist. Can not insert new Lot')
	--	RETURN
	--END

	INSERT INTO [dbo].[House]
           ([LotId]
           ,[Rooms]
           ,[Storeys]
           ,[Person]
           ,[Parking]
           ,[Furniture])
     VALUES
           (@LotId
           ,@Rooms
           ,@Storeys
           ,@Person
           ,@Parking
		   ,@Furniture)

	RETURN @LotId
--end of AddHouse prosedure


EXEC [dbo].[AddHouse]  
			'Ukraine'
           ,'Lviv'
           ,'Lviv'
           ,'Lukasha'
		   ,6
           ,'49.82846685822353'
		   ,'24.014644239118265'
		   ,1
		   , 45
		   ,'description'
		   ,1
		   ,3
		   ,4
		   ,1
		   ,1
		   ,'https://images.pexels.com/photos/1396122/pexels-photo-1396122.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500'
		   SELECT * FROM vLand
	--@Address Data
	--@Country nvarchar(100)
 --   ,@Region  nvarchar(100)
 --   ,@City  nvarchar(100)
 --   ,@Street  nvarchar(100)
 --   ,@Building  nvarchar(100)
	--,@Latitude  nvarchar(100)
	--,@Longitude  nvarchar(100)
	--,@OwnerId int
	--,@Square real
	--,@Description text
	--,@Rooms int
 --   ,@Floor int
 --   ,@Person int
 --   ,@Parking bit
 --   ,@Furniture bit


--SELECT *
--FROM [dbo].[Address]

--SELECT *
--FROM [dbo].[AppUser]

--SELECT*
--FROM Lot

--SELECT *
--FROM [dbo].[House]

--DELETE House
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