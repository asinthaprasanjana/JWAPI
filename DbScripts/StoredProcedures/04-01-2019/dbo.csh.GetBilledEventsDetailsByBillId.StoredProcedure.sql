USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetBilledEventsDetailsByBillId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetBilledEventsDetailsByBillId]
(
@BillId nvarchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	 RecievingId
	,POBE.Id
	,BillId
	,bp.DisplayName
	,PRO.ProductName
	,POBE.ProductId
	,BilledQuantity
	,BilledPrice
	FROM [dbo].[csh.PurchaseOrderBilledEvents] POBE
	INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POBE.PurchaseOrderNo
	INNER JOIN [bsp.BusinessPartner]BP ON BP.BusinessPartnerId = PO.SupplierId
	INNER JOIN [msd_Product] PRO ON PRO.ProductId = POBE.ProductId
	WHERE POBE.BillId IN (SELECT * FROM dbo.splitstring(@BillId))
	ORDER BY POBE.BillId
END 
GO
