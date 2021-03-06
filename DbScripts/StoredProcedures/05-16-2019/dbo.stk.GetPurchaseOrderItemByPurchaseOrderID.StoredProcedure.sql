USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemByPurchaseOrderID]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderItemByPurchaseOrderID]
(

 @PurchaseOrderID VARCHAR(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT 
		
	     POI.Id AS 'purchaseOrderItemId',
		 POI.Id,
	     POI.Discount,
		 POI.ItemId AS 'ProductId',
		 POI.ItemCost,
		 POI.Tax,
		 POI.Quantity,
		 POI.QuantityAfter,
		 POI.ItemId,
		 POI.TotalCost,
	     PP.PackSizeName,
		 P.ProductName
	 
	FROM [stk.PurchaseOrderItems] POI
	INNER JOIN [msd_Product] P ON  POI.ItemId = P.ProductId
	INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = POI.packSizeId
	WHERE  POI.PurchaseNo= @PurchaseOrderID



END 
GO
