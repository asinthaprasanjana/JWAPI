USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllSeasonDetailsById]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllSeasonDetailsById]
(
    @Id INTEGER
 )	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[stk.StockSeason]WHERE Id = @Id
END
GO
