USE LandSellingDB

DROP VIEW IF EXISTS vLand
GO
CREATE VIEW vLand
AS

SELECT h.Id,
       l.[Description],
	   l.[Square],
	   l.PublicationDate,
	   ls.[Name] AS [LotStatus],
	   o.Id AS [OwnerId],
	   o.[Name] AS [OwnerName],
	   o.SurName AS [OwnerSurName],
	   o.[Password],
	   o.PhoneNumber,
	   o.Email,
	   a.Country,
	   a.Region,
	   a.City,
	   a.Street,
	   a.Building,
	   a.Latitude,
	   a.Longitude
FROM Land as h
JOIN Lot as l 
	ON h.LotId = l.Id
JOIN LotStatusType as ls
	ON l.LotStatusId = ls.Id
JOIN AppUser as o
	ON l.OwnerId = o.Id
JOIN [dbo].[Address] as a
	ON a.Id = l.AddressId

GO
SELECT * FROM vLand;

SELECT* FROm Land

