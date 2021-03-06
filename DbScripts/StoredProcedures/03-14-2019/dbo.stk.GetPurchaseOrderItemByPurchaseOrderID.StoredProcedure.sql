USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemByPurchaseOrderID]    Script Date: 14/03/2019 11:47:02 AM ******/
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

 @PurchaseOrderID Nvarchar(20)
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
		 P.ProductName
	   --  POR.RecievedQuantity
	FROM [stk.PurchaseOrderItems] POI
	INNER JOIN [msd_Product] P ON  POI.ItemId = P.ProductId
	WHERE  POI.PurchaseNo= @PurchaseOrderID


	--select * from [stk.PurchaseOrderRecieved] WHERE PurchaseNo = 28 


	--ORDER BY  POI.ID
END 
GO
