USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.UpdateApplicationUser]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.UpdateApplicationUser]
(

  @UserName nvarchar(50),
  @Password nvarchar(50),
  @CurrentPassword nvarchar(50),
  @UserID int, 
  @NIC nvarchar(10),
  @MobileNo int,
  @Email nvarchar(50),
  @Address nvarchar(50)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @userPassword nvarchar (50)

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
