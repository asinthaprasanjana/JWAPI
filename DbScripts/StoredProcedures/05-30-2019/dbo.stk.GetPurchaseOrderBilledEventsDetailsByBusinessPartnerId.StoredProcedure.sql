USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderBilledEventsDetailsByBusinessPartnerId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderBilledEventsDetailsByBusinessPartnerId]
(
@BusinessPartnerId varchar(50),
@PageId            INT
)
AS
BEGIN
	--Select *
	--FROM [dbo].[csh.PurchaseOrderBilledEvents] PBE
	--INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = PBE.PurchaseOrderNo
	--WHERE PO.SupplierId = @BusinessPartnerId

	SELECT 
	POB.Id,
	'B1000' AS DocumentNo,
	250 AS Paid,
	POB.BillDate AS 'CreatedDateTime',
	POB.PaymentStatus,
	 CASE POB.PaymentStatus 
             WHEN 1 THEN 'Fully Paid'
             WHEN 0 THEN 'Payment Pending'
			 WHEN 2 THEN 'Partially Paid'
		END	 AS 'PaymentStatus',
	POB.SupplierBillNo,
	POB.TotalPrice AS 'BillTotal'
	FROM [csh.PurchaseOrderBilled] POB 
	INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POB.PurchaseOrderNo
	WHERE PO.SupplierId = @BusinessPartnerId



END
GO
