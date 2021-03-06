USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemByPurchaseOrderID]    Script Date: 30/05/2019 11:36:25 AM ******/
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
		 POI.ProductId ,
		 POI.ItemCost,
		 POI.Tax,
		 POI.Quantity,
		 POI.QuantityAfter,
		 POI.TotalCost,
	     POI.PackSizeName,
		 POI.ProductName
	FROM [stk.PurchaseOrderItems] POI
	WHERE  POI.PurchaseNo= @PurchaseOrderID



END 
GO
