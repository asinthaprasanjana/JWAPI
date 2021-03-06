USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetBillsByBspId]    Script Date: 16/05/2019 12:39:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetBillsByBspId]
(
@BspId varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PaymentFullyPaidStatus TINYINT = 1;
	SELECT 
	 POB.Id AS BillId
	,COUNT(POBE.ProductId) AS NoOfProducts
	,POB.TotalPrice AS BillTotal
	,(SELECT SUM(Bpay.TotalPrice) FROM [csh.BillPayment]Bpay WHERE Bpay.BillId = POB.Id) AS PaidAmount
	,BP.DisplayName as BSPDisplayName
	,POB.CreatedDateTime
	FROM [dbo].[csh.PurchaseOrderBilled] POB
	INNER JOIN [csh.PurchaseOrderBilledEvents] POBE ON POB.Id = POBE.BillId
	INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POBE.PurchaseOrderNo
	INNER JOIN [bsp.BusinessPartner]BP ON BP.BusinessPartnerId = PO.SupplierId
	WHERE BP.BusinessPartnerId = @BspId  AND POB.PaymentStatus != @PaymentFullyPaidStatus
	GROUP BY POB.Id,BP.DisplayName,POB.CreatedDateTime,POB.TotalPrice

END 
GO
