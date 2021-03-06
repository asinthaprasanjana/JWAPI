USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetProducts]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetProducts]

	@PageNumber SMALLINT,
	@RowsPage SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	SELECT 
			P.ProductId,
			P.SKU,
			P.ProductName,
			PL.AttributeName,
			P.ShortDescription
	FROM [dbo].[msd_Product] P 
	LEFT JOIN [msd.ProductLevels] PL ON PL.id = P.LevelId01 
	ORDER BY P.ProductId
	OFFSET ((@PageNumber - 1) * @RowsPage) ROWS
	FETCH NEXT @RowsPage ROWS ONLY;
END


GO
