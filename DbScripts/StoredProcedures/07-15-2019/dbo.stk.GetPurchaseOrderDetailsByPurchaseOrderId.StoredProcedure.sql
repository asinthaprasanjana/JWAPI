USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderDetailsByPurchaseOrderId]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderDetailsByPurchaseOrderId]
(
@PurchaseOrderId VARCHAR(20),
@CompanyId SMALLint
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	SELECT TOP 1
		    PO.[PurchaseNo],
		    PO.[Recieved],
		    PO.StockDue,
		    PO.PayementDue,
		    PO.CurrencyId,
			PO.QcAvailable,
			PO.isCancelled AS 'IsCancelled',
		    CONVERT(VARCHAR(10), PO.[CreatedDateTime], 110)  AS 'CreatedDateTime',	
					    SHBR.DisplayName AS ShipTo,

			BLBR.DisplayName AS BillTo,
		    PO.ShipLocationId,
			PO.BillLocationId,
			Cu.CurryncyName,
			 CASE PO.Billed 
             WHEN 1 THEN 'Fully Billed'
             WHEN 0 THEN 'Bill Pending'
			 WHEN 2 THEN 'Partially Billed'
          END  AS 'Billed',
			 CASE PO.Paid 
             WHEN 1 THEN 'Fully Paid'
             WHEN 0 THEN 'Payment Pending'
			 WHEN 2 THEN 'Partially Paid'
          END  AS 'Paid',
			BP.DisplayName +' ' +'( ' + BP.BusinessPartnerId+  ' )' AS BusinessPartnerName ,
			PO.Email,
		  CASE PO.Status 
             WHEN 1 THEN 'Issued'
             WHEN 0 THEN 'NotIssued'
          END  AS 'Status',
			PO.ShipLocationId AS branchId,
			PO.ApprovalStatus,
			PO.TempRecieved,
			PO.CreatedUserId		
	 FROM [dbo].[stk.PurchaseOrder] PO
	 INNER JOIN  [msd.Currency] Cu ON Cu.CurrencyId=PO.CurrencyId
	 INNER JOIN  [msd.Branch] SHBR ON SHBR.BranchId=PO.ShipLocationId
	 INNER JOIN  [msd.Branch] BLBR ON BLBR.BranchId=PO.BillLocationId
	 INNER JOIN  [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
	 WHERE PO.PurchaseNo= @PurchaseOrderId
	      
	

END
GO
