USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderItemsBySalesOrderID]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderItemsBySalesOrderID]
(

 @SaleNo varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
		
	     SOI.Id AS 'purchaseOrderItemId',
		 SOI.Id,
	     SOI.Discount,
		 SOI.ProductId,
		 SOI.ItemCost,
		 SOI.Tax,
		 SOI.Quantity,
		 SOI.TotalCost,
		 P.ProductName AS 'ItemName'
	 --   SOR.RecievedQuantity
	FROM [stk.SalesOrderItems] SOI
	INNER JOIN [msd_Product] P ON  SOI.ProductId = P.ProductId
	WHERE  SOI.SaleNo= @SaleNo


	--select * from [stk.PurchaseOrderRecieved] WHERE PurchaseNo = 28 


	--ORDER BY  SOI.ID
END 
GO
