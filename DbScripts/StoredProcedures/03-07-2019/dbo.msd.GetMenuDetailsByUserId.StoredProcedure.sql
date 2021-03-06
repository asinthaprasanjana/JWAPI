USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetMenuDetailsByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetMenuDetailsByUserId]
(
	@CompanyId INT,
    @UserId INT
 )	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	 DECLARE @IsMainMenu TINYINT =1;


	SET NOCOUNT ON;
	SELECT  
	AP.PageId AS 'Id',
	AP.Icon AS 'icon',
	AP.RouterLink AS 'routerLink',
	AP.PageName AS 'label'
	FROM dbo.[msd.ApplicationPages] AP
	WHERE AP.[IsMainMenu] =@IsMainMenu 
	ORDER BY CreatedDateTime ASC
END
GO
