USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecieveDetailsByRecievedId]    Script Date: 01/04/2019 9:46:08 AM ******/
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
	  @RecievedId NVARCHAR(250)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	PO.CompanyId,
	PO.RecievedId ,
	PO.PurchaseNo,
	PO.PurchaseOrderItemId,
	PO.ProductId,
	PO.TotalQuantity,
	PO.RecievedQuantity,
	PO.FreeQuantity,
	P.ProductName,
	POI.ItemCost,
	AU.UserName
	
	FROM [dbo].[stk.PurchaseOrderRecievedEvents] PO
	INNER JOIN [msd_Product] P ON P.ProductId = PO.ProductId
	INNER JOIN [stk.PurchaseOrderItems] POI ON POI.Id  = PO.PurchaseOrderItemId
	INNER JOIN  [msd.ApplicationUserLogInDetails] AU ON AU.UserID = PO.CreatedUserId
	WHERE PO.RecievedId IN( SELECT * FROM dbo.splitstring(@RecievedId))
END
GO
