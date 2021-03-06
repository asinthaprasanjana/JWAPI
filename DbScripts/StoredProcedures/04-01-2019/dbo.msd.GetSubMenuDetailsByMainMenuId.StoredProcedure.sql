USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetSubMenuDetailsByMainMenuId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetSubMenuDetailsByMainMenuId]
(
    @MainMenuId INT,
    @UserRoleId INT
 )	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @PageList NVARCHAR(250)
	
	SELECT
	@PageList= UR.PageIds 
	FROM [usm.UserRoles] UR
	WHERE UR.RoleId = @UserRoleId

	



	SELECT  
	AP.PageId AS 'Id',
	AP.Icon AS 'icon',
	AP.RouterLink AS 'routerLink',
	AP.PageName AS 'label'
	FROM dbo.[msd.ApplicationPages] AP
	WHERE AP.[MainMenuId] = @MainMenuId  AND AP.PageId IN (	SELECT * FROM dbo.splitstring(@PageList)) AND MainMenuId >=0 And IsMainMenu<3
	ORDER BY AP.CreatedDateTime
END
GO
