USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderDetailsByPurchaseOrderId]    Script Date: 01/04/2019 9:46:08 AM ******/
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
@CompanyId int
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
			PO.isCancelled AS 'IsCancelled',
		    CONVERT(VARCHAR(10), PO.[CreatedDateTime], 110)  AS 'CreatedDateTime',
			PO.BillLocationId,
			BLBR.DisplayName AS BillTo,
		    PO.ShipLocationId,
		    SHBR.DisplayName AS ShipTo,
			Cu.CurryncyName,
			BP.DisplayName +' ' +'( ' + BP.BusinessPartnerId+  ' )' AS BusinessPartnerName ,
			PO.Email,

		  CASE PO.Status 
             WHEN 1 THEN 'Issued'
             WHEN 0 THEN 'NotIssued'
          END  AS 'Status',
			PO.ShipLocationId AS branchId,
			PO.ApprovalStatus,
			PO.CreatedUserId

			
	 FROM [dbo].[stk.PurchaseOrder] PO
	 INNER JOIN  [msd.Currency] Cu ON Cu.CurrencyId=PO.CurrencyId
	 INNER JOIN  [msd.Branch] SHBR ON SHBR.BranchId=PO.ShipLocationId
	 INNER JOIN  [msd.Branch] BLBR ON BLBR.BranchId=PO.BillLocationId
	 INNER JOIN  [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
	 WHERE PO.PurchaseNo=@PurchaseOrderId 
	      
	

END
GO
