USE [LandSellingDB]
GO

DECLARE @RC int
DECLARE @LotId int
DECLARE @CustomerId int
DECLARE @ManagerId int
DECLARE @BeginDate date = '2021-08-17'
DECLARE @EndDate date = '2021-09-23'

-- TODO: Set parameter values here.

EXECUTE @RC = [dbo].[AddRent] 
   4
  ,2
  ,4
  ,@BeginDate
  ,@EndDate
GO

SELECT * FROM Lot

SELECT * FROM PriceCoef

SELECT * FROM Rent

DECLARE @Res money
SET @Res = [dbo].CalculateTotalPrice( 4, '2021-08-17', '2021-08-17')

PRINT @Res

--37 * 
