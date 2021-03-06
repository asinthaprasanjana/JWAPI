USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemByPurchaseOrderIDtest]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderItemByPurchaseOrderIDtest]
(

 @PurchaseOrderID varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT
		 DISTINCT POR.PurchaseOrderItemId,
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
		 P.ProductName AS 'ItemName',
	     POR.RecievedQuantity 
	FROM [stk.PurchaseOrderItems] POI
	INNER  JOIN [stk.PurchaseOrderRecieved] POR ON  POI.PurchaseNo=  POR.PurchaseNo 
	INNER JOIN [msd_Product] P ON  POI.ItemId = P.ProductId
	WHERE  POR.PurchaseNo= @PurchaseOrderID


	--select * from [stk.PurchaseOrderRecieved] WHERE PurchaseNo = 28 


	--ORDER BY  POI.ID
END 
GO
