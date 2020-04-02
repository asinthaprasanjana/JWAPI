USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.getUserRolesDetailsByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[usm.getUserRolesDetailsByUserId]
	@UserRoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Select 
		UR.Id,
		UR.RoleName,
		UR.PageIds,
		UR.CreatedUserId,
		UR.CreatedDateTime
	FROM [usm.UserRoles] UR
	WHERE UR.UserRoleId =@UserRoleID

	
	
END
GO
