USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemsDraftDetailsByPurchaseNo]    Script Date: 28/06/2019 4:49:03 PM ******/
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
    POID.ProductId,
	POID.PackSizeId,
	POID.ItemCost,
	POID.PackSizeName,
	POID.PurchaseNo,
	POID.Discount,
	POID.Quantity,
	POID.Tax,
	POID.TotalCost,
	POID.ProductName
	FROM [stk.PurchaseOrderItemsDraftDetails] POID
	WHERE  POID.PurchaseNo= @PurchaseOrderId
END 
GO
