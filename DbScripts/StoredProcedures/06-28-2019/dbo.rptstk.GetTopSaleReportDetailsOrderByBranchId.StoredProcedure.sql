USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[rptstk.GetTopSaleReportDetailsOrderByBranchId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rptstk.GetTopSaleReportDetailsOrderByBranchId]
	
AS
BEGIN
	SELECT
	 'PurchaseOrderReport' AS ReportType,
	 SO.BillLocationId,
	  SUM( SO.NetTotal) AS 'NetTotal'
	FROM [stk.SalesOrder] SO
	GROUP BY SO.BillLocationId
	ORDER BY SUM( SO.NetTotal) DESC
	

END
GO
