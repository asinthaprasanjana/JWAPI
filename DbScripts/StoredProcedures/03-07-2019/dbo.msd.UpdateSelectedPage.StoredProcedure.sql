USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateSelectedPage]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateSelectedPage]
(
@PageId INT,
@PageName VARCHAR(40),
@RouterLink VARCHAR(90),
@Icon VARCHAR(55),
@IsMainMenu TINYINT,
@MainMenuId TINYINT,
@ExpirationDate DATETIME

)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE  [dbo].[msd.ApplicationPages] SET
	  PageName = @PageName,
      RouterLink = @RouterLink,
	  Icon = @Icon,
	  IsMainMenu = @IsMainMenu,
	  MainMenuId = @MainMenuId,
	  ExpirationDate =@ExpirationDate

	WHERE PageId = @PageId
END 
GO
