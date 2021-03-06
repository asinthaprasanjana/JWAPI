USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetPageDetailsByPageId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.GetPageDetailsByPageId]
(
 @PageId INT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	    APP.Id,
		APP.PageId,
		APP.PageName,
		APP.RouterLink,
		APP.Icon,
		APP.IsMainMenu,
		APP.MainMenuId
	FROM [msd.ApplicationPages] APP
	WHERE  APP.PageId= @PageId
END 
GO
