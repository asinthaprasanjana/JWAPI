USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetProductStockCountByBranchId]    Script Date: 26/07/2019 10:10:01 AM ******/
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
	@BranchId SMALLINT,
	@ProductId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@BranchId = -1 AND @ProductId !=  -1)
	BEGIN
		SELECT 
		coalesce(SUM(STL.Quantity),0) as AvailableStock ,
		P.ProductName,
		B.BranchName,
		PP.PackSizeName
		from [stk.StockTransactionLogs] STL
		INNER JOIN [msd_TempProduct] P ON P.ProductId = STL.ProductId
		INNER JOIN [msd.Branch] B ON B.BranchId = STL.BranchId
		LEFT JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = STL.PackSizeId

		WHERE STL.ProductId = @ProductId
		GROUP BY BranchName,PP.PackSizeName, P.ProductName
	END

	IF(@BranchId != -1 AND @ProductId = -1)
	BEGIN
		SELECT coalesce(SUM(STL.Quantity),0) as AvailableStock , 
		P.ProductName,
		B.BranchName ,
	    PP.PackSizeName
		FROM [stk.StockTransactionLogs] STL
		INNER JOIN [msd_TempProduct] P ON P.ProductId = STL.ProductId
		INNER JOIN [msd.Branch] B ON B.BranchId = STL.BranchId
		LEFT JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = STL.PackSizeId
		WHERE  STL.BranchId = @BranchId
		GROUP BY BranchName,p.ProductName,PP.PackSizeName
	END
	
	IF(@BranchId != -1 AND @ProductId != -1)
	BEGIN
		SELECT coalesce(SUM(STL.Quantity),0) as AvailableStock ,
		P.ProductName,
		B.BranchName,
	    PP.PackSizeName
		FROM [stk.StockTransactionLogs] STL
		INNER JOIN [msd_TempProduct] P ON P.ProductId = STL.ProductId
		INNER JOIN [msd.Branch] B ON B.BranchId = STL.BranchId
		LEFT JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = STL.PackSizeId
		WHERE  STL.BranchId = @BranchId AND STL.ProductId = @ProductId
		GROUP BY BranchName,P.ProductName ,PP.PackSizeName
	END
	


END
GO
