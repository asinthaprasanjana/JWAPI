USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderDraftDetailsBySalesOrderId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderDraftDetailsBySalesOrderId]
(
@SaleNo VARCHAR(20),
@CompanyId int
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS


	SELECT TOP 1
		    SO.[SaleNo],
		    SO.PayementDue,
		    SO.CurrencyId,
			SO.NetTotal,
			SO.GrossTotal,
			SO.CustomerId,
			SO.Tax,
			SO.Email,
			SO.Remarks,
			SO.CreditPeriod,
			SO.Discount,
		    CONVERT(VARCHAR(10), SO.[CreatedDateTime], 110)  AS 'CreatedDateTime',
			SO.BillLocationId,
			BLBR.DisplayName AS BillTo,
		    SO.ShipLocationId,
		    SHBR.DisplayName AS ShipTo,
			Cu.CurryncyName,
			SO.Email
			
	 FROM [dbo].[stk.SalesOrderDraftDetails] SO
	 INNER JOIN  [msd.Currency] Cu ON Cu.CurrencyId=SO.CurrencyId
	 INNER JOIN  [msd.Branch] SHBR ON SHBR.BranchId=SO.ShipLocationId
	 INNER JOIN  [msd.Branch] BLBR ON BLBR.BranchId=SO.BillLocationId
	 WHERE SO.SaleNo=@SaleNo
	  

END
GO
