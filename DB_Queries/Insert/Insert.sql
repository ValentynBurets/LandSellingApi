USE [LandSellingDB]
GO

INSERT INTO [dbo].[Address]
           ([Country]
           ,[Region]
           ,[City]
           ,[Street]
           ,[Building]
		   ,[Latitude]
		   ,[Longitude])
     VALUES
           ('Ukraine'
           ,'Lviv'
           ,'Lviv'
           ,'Lukasha'
		   ,3
           ,'49.82846685822353'
		   ,'24.014644239118265'
		   ),
		   
		   ('Ukraine'
           ,'Rivne Region'
           ,'Rivne'
           ,'Shevchenka'
		   ,3
           ,'50.621946350269084'
		   , '26.2423685038517'
		   ),
		   
		   ('Ukraine'
           ,'Rivne Region'
           ,'Demydivka'
           ,'Naberegna'
		   ,3
           ,'50.42233750092434'
		   , '25.34070309283622'
		   ),

		   ('Ukraine'
           ,'Lviv'
           ,'Lviv Region'
           ,'Shevchenko'
		   ,22
           ,'49.85440882783639'
		   ,'24.024228161782307'
		   )
GO

--DELETE FROM [dbo].[Address]
--WHERE Country = 'Ukraine'

SELECT *
FROM [dbo].[Address]


INSERT INTO [dbo].[DurationType]
([Name])
VALUES
	('Month'),
	('Year'),
	('Day'),
	('Week')

SELECT *
FROM [dbo].[DurationType]

INSERT INTO [dbo].[LotStatusType]
([Name])
VALUES
	('Sold'),
	('Rented'),
	('Available')

SELECT *
FROM [dbo].[LotStatusType]

INSERT INTO [dbo].[Role]
([Name])
VALUES
	('Manager'),
	('User')

SELECT * FROM [dbo].[Role]


INSERT INTO [dbo].[RentStatusType]
	([Name])
VALUES
	('Created'),
	('Accepted'),
	('Started'),
	('Finished')

SELECT * FROM [dbo].[RentStatusType]


INSERT INTO [dbo].[SellingStatusType]
	([Name])
VALUES
	('Created'),
	('Sell'),
	('Sold')

SELECT * FROM [dbo].[SellingStatusType]

SELECT * FROM [dbo].[LotStatusType]