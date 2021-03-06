USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecievedDetailsByCompanyId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecievedDetailsByCompanyId]
	(
	  @CompanyId TINYINT,
	  @isPendingBill    TINYINT,
	  @RecievedTypeId SMALLINT,
	  @PageId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	

	IF ( @isPendingBill =1)
	  BEGIN

	    SELECT
			POR.DocumentNo,
			SUM ( POI.TotalCost) AS 'NetTotal',
			POR.PurchaseNo,
			BP.DisplayName AS 'BusinessPartnerName',
			AU.UserName,
			 CASE PO.Billed 
             WHEN 1 THEN 'Fully Billed'
             WHEN 0 THEN 'Pending'
			 WHEN 2 THEN 'Partially Billed'
          END  AS 'Status',
			CONVERT(VARCHAR(12), POR.CreatedDateTime, 100)  AS 'Date'
			FROM  [stk.PurchaseOrderRecievedEvents] POR
			INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POR.PurchaseNo
			INNER JOIN [stk.PurchaseOrderItems] POI ON POI.Id = POR.PurchaseOrderItemId
			INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
			INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = POR.CreatedUserId
			WHERE POR.RecievedTypeId = 3 AND POR.IsBilled = 0
			GROUP BY POR.DocumentNo ,POR.PurchaseNo,BP.DisplayName,AU.UserName,POR.CreatedDateTime,PO.Billed
			ORDER BY  POR.DocumentNo DESC 
	  END
	ELSE
	  BEGIN
			SELECT
				POR.DocumentNo,
				SUM ( POI.TotalCost) AS 'NetTotal',
				POR.PurchaseNo,
				BP.DisplayName AS 'BusinessPartnerName',
				AU.UserName,
				 CASE PO.Billed 
             WHEN 1 THEN 'Fully Billed'
             WHEN 0 THEN 'Pending'
			 WHEN 2 THEN 'Partially Billed'
          END  AS 'Status',
				CONVERT(VARCHAR(12), POR.CreatedDateTime, 100)  AS 'Date'
				FROM  [stk.PurchaseOrderRecievedEvents] POR
				INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POR.PurchaseNo
				INNER JOIN [stk.PurchaseOrderItems] POI ON POI.Id = POR.PurchaseOrderItemId
				INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
				INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = POR.CreatedUserId
				WHERE POR.RecievedTypeId = 3
				GROUP BY POR.DocumentNo ,POR.PurchaseNo,BP.DisplayName,AU.UserName,POR.CreatedDateTime,PO.Billed
				ORDER BY  POR.DocumentNo DESC 
	  END
	



END
GO
