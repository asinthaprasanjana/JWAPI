USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderDetailsByCompanyId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderDetailsByCompanyId]
(
@CompanyId INT
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
	       PO.[PurchaseNo],
		   (BP.[FirstName] +' '+ BP.[LastName]) AS 'Vendor',
		   PO.[Recieved],
		   25000 AS SubTotal,
		   MPT.[Name] AS 'Status',
		   CASE PO.[Billed] 
             WHEN 1 THEN 'Billed'
             WHEN 0 THEN 'Pending'
          END  AS 'Billed',
		   CASE PO.[Recieved] 
             WHEN 1 THEN 'Recieved'
             WHEN 0 THEN 'Pending'
          END  AS 'Recieved',
		   PO.[SupplierId],
		   CONVERT(VARCHAR(10), PO.[CreatedDateTime], 110)  AS 'CreatedDateTime'
	 FROM [stk.PurchaseOrder] PO 
	 INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
	 INNER JOIN [msd.MultipurposeTag] MPT ON MPT.[Data] = PO.[Status]
	 WHERE MPT.[ModuleId] = @ModuleId AND PO.CompanyId = @CompanyId
	 ORDER BY po.[Id] DESC;
	

END
GO
