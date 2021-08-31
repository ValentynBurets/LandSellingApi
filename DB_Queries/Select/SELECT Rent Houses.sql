USE [LandSellingDB]
GO

SELECT H.[Id]
      ,H.[LotId]
      ,H.[Rooms]
      ,H.[Person]
      ,H.[Parking]
      ,H.[Furniture]
      ,H.[Storeys]  
  FROM [dbo].[House] AS H
  WHERE H.LotId 
  
  
  IN (
	SELECT LotId 
	FROM PriceCoef
	WHERE LotId = H.LotId
	)
GO

SELECT * FROM PriceCoef
