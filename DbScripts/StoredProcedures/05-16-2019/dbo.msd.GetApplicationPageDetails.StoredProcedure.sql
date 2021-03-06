USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetApplicationPageDetails]    Script Date: 16/05/2019 12:39:09 PM ******/
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
    DECLARE @RowsPage SMALLINT = 100,
	        @pageId   TINYINT;
	
	SET @pageId = 0;
	IF (@PageId = 0)
	  BEGIN
	     SELECT
	     AP.PageId,
	AP.PageName ,
	AP.RouterLink,
	AP.PriorityNo,
	AP.Icon,
	AP.MainMenuId,
	AP.IsMainMenu,
	
	CONVERT(VARCHAR,AP.ExpirationDate, 100) AS Date
	FROM dbo.[msd.ApplicationPages] AP
	ORDER BY CreatedDateTime ASC
	  END
	ELSE
	  BEGIN
	   SELECT
	AP.PageId   ,
	AP.PageName ,
	AP.RouterLink,
	AP.Icon,
	--AP.ExpirationDate,
	AP.MainMenuId,
	AP.IsMainMenu
	--CONVERT(varchar,AP.ExpirationDate, 100) AS Date
	FROM dbo.[msd.Test] AP
	ORDER BY CreatedDateTime ASC
	OFFSET ((@PageId - 1) * @RowsPage) ROWS
    FETCH NEXT @RowsPage ROWS ONLY;
	 END

	
	
END
GO
