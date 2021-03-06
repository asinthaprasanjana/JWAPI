USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecievedDetailsByPurhcaseOrderId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecievedDetailsByPurhcaseOrderId]
(

 @PurchaseOrderID Nvarchar(20)
)
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	SET NOCOUNT ON;
	SELECT 
	
	     POR.Id,   
		 POR.ProductId ,
		-- PR.RecievedId,
		 POI.ItemCost,
		 POR.PurchaseOrderItemId,
	     P.ProductName ,
	    POR.RecievedQuantity,
		POR.FreeQuantity,
	    POR.PurchaseNo,
		POR.TotalQuantity AS 'Quantity',
	    AUL.UserName,
		CONVERT(VARCHAR, POR.LastModifiedDateTime, 100) AS CreatedDateTime
	FROM [stk.PurchaseOrderRecieved] POR   -- POR table not PORE
	INNER JOIN [msd_Product] P ON  POR.ProductId = P.ProductId
	INNER JOIN [stk.PurchaseOrderItems] POI ON POI.Id = POR.PurchaseOrderItemId
	LEFT JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = POR.LastModifiedUserId
	WHERE  POR.PurchaseNo= @PurchaseOrderID

END 

GO
