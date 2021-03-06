USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemsDraftDetailsByPurchaseNo]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderItemsDraftDetailsByPurchaseNo]
(

 @PurchaseOrderId Nvarchar(15)
)

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	POID.Id,
    POID.ItemId AS 'ProductId',
	POID.ItemCost,
	POID.PurchaseNo,
	POID.Discount,
	POID.Quantity,
	POID.Tax,
	POID.TotalCost,
	P.ProductName
	FROM [stk.PurchaseOrderItemsDraftDetails] POID
	INNER JOIN [msd_Product] P ON P.ProductId = POID.ItemId
	WHERE  POID.PurchaseNo= @PurchaseOrderId
END 
GO
