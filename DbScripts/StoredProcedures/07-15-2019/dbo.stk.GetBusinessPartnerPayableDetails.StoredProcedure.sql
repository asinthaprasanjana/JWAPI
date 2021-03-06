USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetBusinessPartnerPayableDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetBusinessPartnerPayableDetails]
(
@BusinessPartnerId varchar(50),
@PageId            SMALLINT,
@BusinessPartnerTypeId SMALLINT
)
AS
BEGIN
	
	     DECLARE @FullyPaidStatus SMALLINT = 1

	IF ( @BusinessPartnerTypeId =1 )
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
   ELSE 
       BEGIN
	      SELECT 
		   S.Id,
		  S.NetTotal AS 'BillTotal',
		  S.InvoiceNo AS 'DocumentNo',
		  S.NetTotal - S.PaidPrice AS 'BalanceAmount',
		  S.PaidPrice AS PaidAmount,
		  S.PaymentStatus,
	      CASE S.PaymentStatus 
             WHEN 1 THEN 'Fully Paid'
             WHEN 0 THEN 'Payment Pending'
			 WHEN 2 THEN 'Partially Paid'
		   END	 AS 'PaymentStatus',
		  CONVERT(VARCHAR(13), S.CreatedDateTime, 100) AS 'CreatedDateTime',
		  AU.UserName
		  FROM [csh.SalesOrderInvoiced] S
		  INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = S.CreatedUserId
		   WHERE S.CustomerId = @BusinessPartnerId 
		   AND ApprovalStatus IN (0,2) AND S.PaymentStatus <> @FullyPaidStatus

	   END



END
GO
