USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetNetTotalOfSalesNPurchase]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetNetTotalOfSalesNPurchase]
	@CompanyId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @salesID INT = 2,
			@purchaseId INT = 1
			
	
	SELECT coalesce(SUM(SO.NetTotal),0) AS NetTotal,reportId = @salesID
	FROM [stk.SalesOrder] SO
	--WHERE  CONVERT(varchar(10),SO.CreatedDateTime,111) = CONVERT(VARCHAR(10), getdate(), 111) AND SO.CompanyId = @CompanyId
	WHERE CAST(SO.CreatedDateTime AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND CAST(GETDATE() AS DATE)

	SELECT coalesce(SUM(PO.NetTotal),0) AS NetTotal,reportId = @purchaseId
	FROM [stk.PurchaseOrder] PO
	--WHERE  CONVERT(varchar(10),PO.CreatedDateTime,111) = CONVERT(VARCHAR(10), getdate(), 111) AND PO.CompanyId = @CompanyId
	WHERE CAST(PO.CreatedDateTime AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND CAST(GETDATE() AS DATE)


END
GO
