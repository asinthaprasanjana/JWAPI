USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderDraftItemsBySalesOrderID]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderDraftItemsBySalesOrderID]
(

 @SaleNo Nvarchar(20)
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
		 SOI.ItemId AS 'ProductId',
		 SOI.ItemCost,
		 SOI.Tax,
		 SOI.Quantity,
		 SOI.ItemId,
		 SOI.TotalCost,
		 P.ProductName AS 'ItemName'
	 --   SOR.RecievedQuantity
	FROM [stk.SalesOrderItemsDraftDetails] SOI
	INNER JOIN [msd_Product] P ON  SOI.ItemId = P.ProductId
	WHERE  SOI.SaleNo= @SaleNo


	--select * from [stk.PurchaseOrderRecieved] WHERE PurchaseNo = 28 


	--ORDER BY  SOI.ID
END 
GO
