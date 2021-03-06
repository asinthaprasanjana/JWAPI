USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.UpdateUserRolesDetailsByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.UpdateUserRolesDetailsByUserId]
	
	@UserRoleID INT,
	@UserId INT,
	@CreatedUserId int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
  IF EXISTS(SELECT 1 FROM [msd.ApplicationUserLogInDetails]  WHERE UserId = @UserId )
  BEGIN
			UPDATE [msd.ApplicationUserLogInDetails] SET
			RoleId = @UserRoleID
			WHERE  UserId = @UserId
  END

  ELSE
  BEGIN

     RAISERROR('This User Role Details Does Not Exists!', 16, 1);

  END
END

GO
