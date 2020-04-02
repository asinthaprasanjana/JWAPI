USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[rptstk.GetTopPurchaseReportDetailsOrderByBranchId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rptstk.GetTopPurchaseReportDetailsOrderByBranchId]

	
AS
BEGIN
	SELECT 
	 'PurchaseOrderReport' AS ReportType,
	PO.BillLocationId,
	 SUM( PO.NetTotal) AS 'NetTotal'
	FROM  [dbo].[stk.PurchaseOrder] PO
	GROUP BY PO.BillLocationId
	ORDER BY SUM( PO.NetTotal) DESC
	

END
GO
