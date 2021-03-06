USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.UpdateUserRolesDetailsByUserRoleId]    Script Date: 15/07/2019 12:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.UpdateUserRolesDetailsByUserRoleId]
	
	@UserRoleID int,
	@PageIds varchar(175),
	@CreatedUserId int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
  IF EXISTS(SELECT 1 FROM [usm.UserRoles]  WHERE RoleId = @UserRoleID)
  BEGIN
			UPDATE [usm.UserRoles] SET
			PageIds=@PageIds
			WHERE  RoleId  = @UserRoleID
  END

  ELSE
  BEGIN

     RAISERROR('This User Role Details Does Not Exists!', 16, 1);

  END
END
GO
