USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderDetailsBySaleNos]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderDetailsBySaleNos]
(
@SaleNos varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT
		    SO.[SaleNo],
		    SO.PayementDue,
		    SO.CurrencyId,
			SO.NetTotal,
			SO.CustomerId,
			SO.CompanyId,
			SO.GrossTotal,
			SO.Email,
			SO.Tax,
			SO.Discount,
		    SO.CreatedDateTime  AS 'CreatedDateTime',
			SO.BillLocationId,
			BLBR.DisplayName AS BillTo,
		    SO.ShipLocationId,
		    SHBR.DisplayName AS ShipTo,
			Cu.CurryncyName,
			SO.Email,
			Cu.CurryncyName,
			BSP.DisplayName

			
	 FROM [dbo].[stk.SalesOrder] SO
	 INNER JOIN  [msd.Currency] Cu ON Cu.CurrencyId=SO.CurrencyId
	 INNER JOIN  [msd.Branch] SHBR ON SHBR.BranchId=SO.ShipLocationId
	 INNER JOIN  [msd.Branch] BLBR ON BLBR.BranchId=SO.BillLocationId
	 INNER JOIN  [bsp.BusinessPartner] BSP ON BSP.BusinessPartnerId=SO.CustomerId 

	WHERE SO.SaleNo IN (SELECT * FROM dbo.splitstring(@SaleNos))
	ORDER BY SO.SaleNo
END 
GO
