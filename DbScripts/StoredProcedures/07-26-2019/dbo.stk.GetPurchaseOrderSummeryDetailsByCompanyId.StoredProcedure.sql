USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderSummeryDetailsByCompanyId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderSummeryDetailsByCompanyId]
(
@CompanyId SMALLINT,
@PageId    SMALLINT
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	   DECLARE  @PurchaseOrderStatus VARCHAR,
	            @ModuleId            TINYINT = 1;
			

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS


	SELECT 
	 --CASE PO.[QcAvailable] 
  --           WHEN 1 THEN  PO.PurchaseNo
  --           WHEN 0 THEN  PO.PurchaseNo
		--	 END  AS 'PurchaseNo',
			
	     PO.[PurchaseNo],
		  BP.DisplayName AS 'Vendor',
		   PO.[Recieved],
		   PO.StockDue,
		   PO.PayementDue,
		   PO.CurrencyId,
		   25000 AS SubTotal,
		--   MPT.[Name] AS 'Status',
		   CASE PO.[Billed] 
             WHEN 1 THEN 'Billed'
             WHEN 0 THEN 'Pending'
			 WHEN 2 THEN 'Partially Billed'
           END  AS 'Billed',
		   CASE PO.[Recieved] 
             WHEN 1 THEN 'Recieved'
             WHEN 0 THEN 'Pending'
			  WHEN 2 THEN 'Partially Recieved'
           END  AS 'Recieved',
		    CASE PO.[Status] 
             WHEN 1 THEN 'Issued'
             WHEN 0 THEN 'Not Issued'
           END  AS 'IssueStatus',
		   PO.[SupplierId],   
		   CONVERT(VARCHAR(20), PO.[CreatedDateTime], 100 ) AS CreatedDateTime,
			PO.BillLocationId AS BillTo,
			PO.ShipLocationId AS ShipTo,
			PO.CurrencyId,
			PO.Email
	 FROM [stk.PurchaseOrder] PO 
	 INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
	 ORDER BY po.[Id] DESC 
   

END
GO
