USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.getUserRolesDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.getUserRolesDetails]
(
@CompanyId INT
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT 
	UR.RoleName AS UserRoleName,
	UR.PageIds AS pageIdList,
	UR.Id,
	UR.RoleId,
	UR.CompanyID
	FROM [usm.UserRoles] UR
	ORDER BY CreatedDateTime DESC

	
	
END
GO
