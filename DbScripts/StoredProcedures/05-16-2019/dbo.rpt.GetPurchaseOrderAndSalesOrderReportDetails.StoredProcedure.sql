USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[rpt.GetPurchaseOrderAndSalesOrderReportDetails]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[rpt.GetPurchaseOrderAndSalesOrderReportDetails]
(

 @CompanyId INT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
select S.ItemId as ProductId , SUM(s.Quantity) as Total from [stk.SalesOrderItems] S
group by s.ItemId


Select p.ItemId as ProductId, SUM (p.Quantity) as Total from [stk.PurchaseOrderItems] P 
WHERE P.ItemId IN (select S.ItemId from [stk.SalesOrderItems] S
group by s.ItemId)
group by p.ItemId 
END 
GO
