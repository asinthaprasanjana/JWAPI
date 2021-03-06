USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderItemsDraftDetailsByPurchaseNo]    Script Date: 30/05/2019 11:36:25 AM ******/
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
