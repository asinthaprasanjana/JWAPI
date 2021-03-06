USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetApplicationPageDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetApplicationPageDetails]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
	SELECT 
	AP.PageId   ,
	AP.PageName ,
	AP.RouterLink,
	AP.Icon,
	AP.ExpirationDate,
	AP.MainMenuId,
	AP.IsMainMenu,
	CONVERT(varchar,AP.ExpirationDate, 100) AS Date
	FROM dbo.[msd.ApplicationPages] AP
	ORDER BY CreatedDateTime ASC

	
	
END
GO
