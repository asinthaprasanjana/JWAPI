USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.getUserRolesDetailsByPrivilegeId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.getUserRolesDetailsByPrivilegeId]
(
@CompanyId INT,
@PrivilegeId INT
)	
AS




BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @RoleIds varchar(100);
	SET @RoleIds=(SELECT TOP 1  RoleIds FROM [usm.UserRolePrivileges] WHERE PrivilegeId=@PrivilegeId)
	SELECT 
	UR.RoleName AS UserRoleName,
	UR.Id,
	UR.RoleId,
	UR.CompanyID
	FROM [usm.UserRoles] UR
	WHERE UR.CompanyID = 1 AND UR.RoleId IN ((SELECT * FROM dbo.splitstring(@RoleIds)))
	ORDER BY CreatedDateTime DESC

	
	
END
GO
