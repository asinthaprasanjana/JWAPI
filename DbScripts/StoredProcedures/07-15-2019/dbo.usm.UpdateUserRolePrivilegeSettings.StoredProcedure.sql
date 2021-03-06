USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.UpdateUserRolePrivilegeSettings]    Script Date: 15/07/2019 12:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.UpdateUserRolePrivilegeSettings]
@PrivilegeId INT,
@Status INT,
@RoleIds VARCHAR(50)
	
AS
BEGIN
	UPDATE [dbo].[usm.UserRolePrivileges] SET  
		IsActive=@Status
		WHERE PrivilegeId=@PrivilegeId

		IF(@Status=1)
		BEGIN
		UPDATE [dbo].[usm.UserRolePrivileges] SET  
		RoleIds=@RoleIds
		WHERE PrivilegeId=@PrivilegeId
		END

END
GO
