USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetMainMenuModelDetails]    Script Date: 15/07/2019 12:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.GetMainMenuModelDetails]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @IsMainMenu TINYINT =1;
	
	Select *
	FROM [dbo].[msd.ApplicationPages]
	WHERE IsMainMenu = @IsMainMenu

	
	
END
GO
