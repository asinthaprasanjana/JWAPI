USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllPurchaseOrderBillDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllPurchaseOrderBillDetails]
(
	@PageId INT
)
AS
BEGIN
	SELECT
	POB.Id,
	POB.BillDate,
	POB.SupplierBillNo,
	BP.BusinessPartnerId,
	BP.Email AS 'BusinessPartnerEmail',
	BP.DisplayName AS 'BusinessPartnerName',
	POB.TotalPrice AS 'NetTotal'
	FROM [csh.PurchaseOrderBilled] POB
	INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POB.PurchaseOrderNo
	INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
	


END
GO
