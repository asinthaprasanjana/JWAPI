USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetMenuDetailsByUserRoleId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetMenuDetailsByUserRoleId]
(
	@CompanyId INT,
    @UserRoleId INT
 )	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	 DECLARE @IsMainMenu TINYINT =1,
	         @PageList   NVARCHAR(250);

	      SELECT
	@PageList= UR.PageIds 
	FROM [usm.UserRoles] UR
	WHERE UR.RoleId = @UserRoleId


	SET NOCOUNT ON;
	SELECT  
	AP.PageId AS 'Id',
	AP.Icon AS 'icon',
	AP.RouterLink AS 'routerLink',
	AP.PageName AS 'label'
	FROM dbo.[msd.ApplicationPages] AP
	WHERE AP.[IsMainMenu] =@IsMainMenu AND  AP.PageId IN (SELECT * FROM dbo.splitstring(@PageList))
	ORDER BY AP.CreatedDateTime ASC
END
GO
