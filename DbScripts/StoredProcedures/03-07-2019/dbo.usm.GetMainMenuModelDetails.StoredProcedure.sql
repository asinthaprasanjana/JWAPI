USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetMainMenuModelDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
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
