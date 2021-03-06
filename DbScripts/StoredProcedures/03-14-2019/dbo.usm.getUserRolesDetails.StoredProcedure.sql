USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.getUserRolesDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
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
	UR.RoleName AS userRoleName,
	UR.PageIds AS pageIdList,
	UR.Id,
	UR.RoleId,
	UR.CompanyID
	FROM [usm.UserRoles] UR
	WHERE UR.CompanyID = @CompanyId
	ORDER BY CreatedDateTime DESC

	
	
END
GO
