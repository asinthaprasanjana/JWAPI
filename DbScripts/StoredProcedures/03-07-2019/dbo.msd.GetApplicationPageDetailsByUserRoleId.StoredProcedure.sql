USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetApplicationPageDetailsByUserRoleId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetApplicationPageDetailsByUserRoleId]
(
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

	


 	SELECT * FROM  [msd.ApplicationPages] AP WHERE AP.PageId IN (	SELECT * FROM dbo.splitstring(@PageList)
	
)
	
END
GO
