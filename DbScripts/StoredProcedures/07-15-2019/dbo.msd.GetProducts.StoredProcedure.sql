USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetProducts]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetProducts]

	@PageNumber INT,
	@RowsPage INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	 

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	DECLARE @count int

	SELECT @count = COUNT(p.ProductId)
	FROM msd_Product p

	SELECT 
			P.ProductId,
			P.SKU,
			P.ProductName,
			PL.AttributeName,
			P.ShortDescription,
			@count as productCount
	FROM [dbo].[msd_Product] P 
	LEFT JOIN [msd.ProductLevels] PL ON PL.id = P.LevelId01 
	ORDER BY P.ProductId
	OFFSET ((@PageNumber - 1) * @RowsPage) ROWS
	FETCH NEXT @RowsPage ROWS ONLY;
END


GO
