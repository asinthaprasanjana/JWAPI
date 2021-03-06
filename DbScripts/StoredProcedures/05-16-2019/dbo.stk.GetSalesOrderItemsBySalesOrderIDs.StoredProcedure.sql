USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderItemsBySalesOrderIDs]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderItemsBySalesOrderIDs]
(

 @SaleNos varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
		
	     SOI.Id AS 'salesOrderItemId',
		 SOI.SaleNo,
	     SOI.Discount,
		 SOI.ItemId AS 'ProductId',
		 SOI.ItemCost,
		 SOI.Tax,
		 SOI.Quantity,
		 SOI.ItemId,
		 SOI.TotalCost,
		 P.ProductName AS 'ItemName'
	 --   SOR.RecievedQuantity
	FROM [stk.SalesOrderItems] SOI
	INNER JOIN [msd_Product] P ON  SOI.ItemId = P.ProductId
	WHERE SOI.SaleNo IN (SELECT * FROM dbo.splitstring(@SaleNos))


	--select * from [stk.PurchaseOrderRecieved] WHERE PurchaseNo = 28 


	--ORDER BY  SOI.ID
END 
GO
