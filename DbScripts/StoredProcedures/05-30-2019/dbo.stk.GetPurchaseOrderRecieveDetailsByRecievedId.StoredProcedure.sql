USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecieveDetailsByRecievedId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecieveDetailsByRecievedId]
	(
	  @RecievedId VARCHAR(250),
	  @RecievedTypeId INT

	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @BillPendingStatus BIT = 0;

	SELECT 
	PO.CompanyId,
	PO.RecievedId ,
	PO.PurchaseNo,
	PO.PurchaseOrderItemId,
	PO.ProductId,
	PO.TotalQuantity,
	PO.RecievedQuantity,
	PO.FreeQuantity,
	POI.ProductName,
	POI.ItemCost,
	PP.PackSizeName,
	AU.UserName	
	FROM [dbo].[stk.PurchaseOrderRecievedEvents] PO
	INNER JOIN [stk.PurchaseOrderItems] POI ON POI.Id  = PO.PurchaseOrderItemId
	INNER JOIN  [msd.ApplicationUserLogInDetails] AU ON AU.UserID = PO.CreatedUserId
	INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = POI.packSizeId
	WHERE PO.RecievedId IN( SELECT * FROM dbo.splitstring(@RecievedId)) AND PO.IsBilled = @BillPendingStatus AND PO.RecievedTypeId=3 AND PO.RecievedId>0
	Order By PO.RecievedId ASC;
END
GO
