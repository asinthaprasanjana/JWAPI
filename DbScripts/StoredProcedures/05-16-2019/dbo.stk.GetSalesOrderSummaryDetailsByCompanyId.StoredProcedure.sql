USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderSummaryDetailsByCompanyId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderSummaryDetailsByCompanyId]
(
 @CompanyId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

   BEGIN

    SELECT 
	SOD.CreatedUserId,
	SOD.SaleNo,
	SOD.NetTotal,
	BP.DisplayName,
	COUNT(PID.Id) AS COUNT,
	convert(varchar(10), SOD.CreatedDateTime, 120) AS CreatedDateTime
	FROM [stk.SalesOrder] SOD
    INNER JOIN [bsp.BusinessPartner] BP ON SOD.CustomerId=BP.BusinessPartnerId 
	INNER JOIN  [stk.SalesOrderItems] PID ON PID.SaleNo= SOD.SaleNo 
	WHERE SOD.CompanyId = @CompanyId AND SOD.Invoiced=0
	GROUP BY SOD.SaleNo,SOD.NetTotal,BP.DisplayName,SOD.CreatedDateTime,SOD.CreatedUserId
	ORDER BY SOD.CreatedDateTime DESC

    END
END
GO
