USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetProductStockCountByBranchId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetProductStockCountByBranchId]
	@BranchId INT,
	@ProductId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@BranchId = -1 AND @ProductId !=  -1)
	BEGIN
		SELECT coalesce(SUM(STL.Quantity),0) as availableStock , P.ProductName, B.BranchName
		from [stk.StockTransactionLogs] STL
		INNER JOIN [msd_Product] P ON P.ProductId = STL.ProductId
		INNER JOIN [msd.Branch] B ON B.BranchId = STL.BranchId
		WHERE STL.ProductId = @ProductId
		GROUP BY BranchName,ProductName
	END

	IF(@BranchId != -1 AND @ProductId = -1)
	BEGIN
		SELECT coalesce(SUM(STL.Quantity),0) as availableStock , P.ProductName, B.BranchName
		from [stk.StockTransactionLogs] STL
		INNER JOIN [msd_Product] P ON P.ProductId = STL.ProductId
		INNER JOIN [msd.Branch] B ON B.BranchId = STL.BranchId
		WHERE  STL.BranchId = @BranchId
		GROUP BY BranchName,ProductName
	END
	
	IF(@BranchId != -1 AND @ProductId != -1)
	BEGIN
		SELECT coalesce(SUM(STL.Quantity),0) as availableStock , P.ProductName, B.BranchName
		from [stk.StockTransactionLogs] STL
		INNER JOIN [msd_Product] P ON P.ProductId = STL.ProductId
		INNER JOIN [msd.Branch] B ON B.BranchId = STL.BranchId
		WHERE  STL.BranchId = @BranchId AND STL.ProductId = @ProductId
		GROUP BY BranchName,ProductName
	END
	


END
GO
