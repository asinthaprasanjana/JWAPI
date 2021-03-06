USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.UpdateApplicationUser]    Script Date: 15/07/2019 12:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.UpdateApplicationUser]
(

  @UserName varchar(50),
  @Password varchar(50),
  @CurrentPassword varchar(50),
  @UserID smallint, 
  @NIC varchar(10),
  @MobileNo int,
  @Email varchar(50),
  @Address varchar(50)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @userPassword varchar (50)

	IF EXISTS ( SELECT * FROM [msd.ApplicationUserDetails] WHERE UserId=@UserID)
	BEGIN
	SELECT @userPassword= Password FROM [msd.ApplicationUserLogInDetails] WHERE UserId=@UserID
		
		IF(@CurrentPassword = @userPassword)
			BEGIN
				UPDATE [msd.ApplicationUserDetails] SET
					MobileNo=@MobileNo,
					Address=@Address,
					Email=@Email
				WHERE UserID=@UserID
		
				UPDATE [msd.ApplicationUserLogInDetails] SET
					UserName=@UserName											
				WHERE UserId=@UserID

					IF (@Password IS NOT NULL)
						BEGIN
						print('printed');
							UPDATE [msd.ApplicationUserLogInDetails] SET
								Password=@Password
							WHERE UserId=@UserID
						END
			END
		ELSE
			BEGIN
				RAISERROR('Invalid Current Password',16,1)
			END

	END
	ELSE
		BEGIN
			RAISERROR('User does not exist',16,1)
			RETURN 0
		END
END 
GO
