USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecievedEventDetailsByPurhcaseOrderId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecievedEventDetailsByPurhcaseOrderId]
(

 @PurchaseOrderID Nvarchar(20)
)
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	SET NOCOUNT ON;
	SELECT 
		
		 PORE.ProductId ,
		 PORE.RecievedId,
		 POI.ItemCost,
	     P.ProductName ,
	    PORE.RecievedQuantity,
		PORE.FreeQuantity,
	--	PORE.TotalQuantity AS 'Quantity'
	   PORE.CreatedDateTime 
	FROM [stk.PurchaseOrderRecievedEvents] PORE   -- PORE table not POREE
	INNER JOIN [msd_Product] P ON  PORE.ProductId = P.ProductId
	INNER JOIN [stk.PurchaseOrderItems] POI ON POI.Id = PORE.PurchaseOrderItemId
	WHERE  PORE.PurchaseNo= @PurchaseOrderID

END 

GO
