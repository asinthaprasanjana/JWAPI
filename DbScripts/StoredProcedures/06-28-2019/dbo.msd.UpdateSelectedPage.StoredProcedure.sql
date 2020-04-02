USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateSelectedPage]    Script Date: 28/06/2019 4:49:03 PM ******/
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
@PriorityNo SMALLINT,
@IsActive TINYINT,
@MainMenuId TINYINT,
@ExpirationDate DATETIME

)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF EXISTS ( SELECT 1 FROM [msd.ApplicationPages]  WHERE Id = @PageId )
	   BEGIN
	      UPDATE  [dbo].[msd.ApplicationPages] SET
		  PageName = @PageName,
		  RouterLink = @RouterLink,
		  Icon = @Icon,
		  IsMainMenu = @IsMainMenu,
		  MainMenuId = @MainMenuId,
		  IsActive = @IsActive,
	      ExpirationDate =@ExpirationDate

	     WHERE PageId = @PageId
	   END
	
END 
GO
