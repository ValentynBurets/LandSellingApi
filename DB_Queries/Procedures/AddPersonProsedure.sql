DROP PROCEDURE IF EXISTS dbo.AddPerson
GO
CREATE PROCEDURE dbo.AddPerson
(
	@PersonName nvarchar(100), 
	@PersonSurName nvarchar(100),
	@PersonPhoneNumber nvarchar(100),
	@PersonEmail nvarchar(100),
	@PassWord nvarchar(100),
	@RoleId int
)
AS
BEGIN
	
	DECLARE @PersonId int = 0
	DECLARE @uperr int  
	DECLARE @maxerr int  

	SELECT @PersonId = [dbo].[AppUser].Id
				FROM [dbo].[AppUser]
				WHERE @PersonName = [dbo].[AppUser].[Name] AND
				@PersonSurName = [dbo].[AppUser].Surname

	IF (@PersonId != 0)
		BEGIN
			IF EXISTS (SELECT *
				FROM [dbo].[AppUser]
				WHERE @PersonName = [dbo].[AppUser].[Name] AND
					@PersonSurName = [dbo].[AppUser].Surname AND
					@PersonPhoneNumber = [dbo].[AppUser].PhoneNumber AND
					@PersonEmail = [dbo].[AppUser].Email)
				BEGIN
					PRINT 'Person exist in table'  
					RETURN @PersonId
				END
			ELSE
				PRINT 'Person exist in table Try update person data. ' +  CHAR(13) + ' CustomerId = ' + CAST(@PersonId AS nvarchar);  
			
				BEGIN TRAN
					
					UPDATE [dbo].[AppUser]
					SET PhoneNumber = @PersonPhoneNumber,
						Email = @PersonEmail,
						[PassWord] = @PassWord
					WHERE @PersonId = [dbo].[AppUser].Id

					BEGIN
						SET @uperr = @@error  
						IF @uperr > @maxerr  
						SET @maxerr = @uperr  
  
						-- If an error occurred, roll back  
						IF @maxerr <> 0  
							BEGIN  
								ROLLBACK  
								PRINT 'did bot updated ' +  CHAR(13) + ' Transaction rolled back'  
							END
						ELSE  
							BEGIN  
								COMMIT  
								PRINT 'updated successfully ' +  CHAR(13) + ' Transaction committed'  
							END
					END

					RETURN @PersonId
		END
			
	ELSE
		BEGIN 
		--Person don't exist in table
		--Insert person

		PRINT 'Person did not exist in table ' +  CHAR(13) + ' Try to Insert in table'  

		BEGIN TRAN

		DECLARE @InsertedPersonId int-- = (SELECT MAX(Id) + 1 FROM [dbo].[AppUser])		

		INSERT INTO [dbo].[AppUser]
		([Name], Surname, PhoneNumber, RoleId, Email, [Password])
		VALUES (
			@PersonName, 
			@PersonSurName,
			@PersonPhoneNumber,
			@RoleId,
			@PersonEmail,
			@PassWord
			)

		SELECT @InsertedPersonId = Id 
		FROM [dbo].[AppUser]
		WHERE @PersonName = [dbo].[AppUser].[Name] AND
					@PersonSurName = [dbo].[AppUser].Surname AND
					@PersonPhoneNumber = [dbo].[AppUser].PhoneNumber AND
					@PersonEmail = [dbo].[AppUser].Email 

		BEGIN
			SET @uperr = @@error  
			IF @uperr > @maxerr  
			SET @maxerr = @uperr  
  
			-- If an error occurred, roll back  
			IF @maxerr <> 0  
				BEGIN  
					ROLLBACK  
					PRINT 'did bot updated ' +  CHAR(13) + ' Transaction rolled back'  
				END
			ELSE  
				BEGIN  
					COMMIT  
					PRINT 'updated successfully ' +  CHAR(13) + ' Transaction committed'  
				END
		END

		RETURN @InsertedPersonId

	END
END

--tests
--PRINT dbo.AddCustomer('Valentyn', 'Ivanov', '0943573523', 'Ivano3v@gmail.com')

DECLARE  @returnId int  
EXEC @returnId= dbo.AddPerson 'Sergey', 'Petrov', '09433332544', 'Serg@gmail.com', '1111', 2  
PRINT(@returnId)  

SELECT * FROM [dbo].[AppUser]

INSERT INTO [dbo].[AppUser]
		(Id, [Name], Surname, PhoneNumber, Email, [Password], [RoleId])
		VALUES ( 7, 'Valentyn', 'Petrov', '0943334523', 'PetroV@gmail.com', '1111', 2 )


SELECT *
FROM [dbo].[AppUser]

SELECT*
FROM [dbo].[Role]