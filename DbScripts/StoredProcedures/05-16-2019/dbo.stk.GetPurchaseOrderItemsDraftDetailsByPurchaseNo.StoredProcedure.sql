USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemsDraftDetailsByPurchaseNo]    Script Date: 16/05/2019 12:39:09 PM ******/
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

 @PurchaseOrderId varchar(15)
)

AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	POID.Id,
    POID.ItemId AS 'ProductId',
	POID.PackSizeId,
	POID.ItemCost,
	PP.PackSizeName,
	POID.PurchaseNo,
	POID.Discount,
	POID.Quantity,
	POID.Tax,
	POID.TotalCost,
	P.ProductName
	FROM [stk.PurchaseOrderItemsDraftDetails] POID
	INNER JOIN [msd_Product] P ON P.ProductId = POID.ItemId
	LEFT JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = POID.packSizeId
	WHERE  POID.PurchaseNo= @PurchaseOrderId
END 
GO
