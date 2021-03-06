USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderBilledDetailsByBusinessPartnerId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderBilledDetailsByBusinessPartnerId]
(
@BusinessPartnerId varchar(50),
@PageId            INT
)
AS
BEGIN
	

	SELECT 
	POB.Id,
	POB.DocumentNo,
	POB.PaidPrice AS PaidAmount,
	POB.TotalPrice - POB.PaidPrice AS 'BalanceAmount',
	CONVERT(VARCHAR(13), POB.BillDate, 100) AS 'CreatedDateTime',
	POB.PaymentStatus,
	 CASE POB.PaymentStatus 
             WHEN 1 THEN 'Fully Paid'
             WHEN 0 THEN 'Payment Pending'
			 WHEN 2 THEN 'Partially Paid'
		END	 AS 'PaymentStatus',
	POB.SupplierBillNo,
	POB.TotalPrice AS 'BillTotal',
	AU.UserName
	FROM [csh.PurchaseOrderBilled] POB 
	INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POB.PurchaseOrderNo
	INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = POB.CreatedUserId
	WHERE PO.SupplierId = @BusinessPartnerId
	ORDER BY POB.ID DESC



END
GO
