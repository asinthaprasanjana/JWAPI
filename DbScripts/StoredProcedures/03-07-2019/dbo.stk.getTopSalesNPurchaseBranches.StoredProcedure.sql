USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.getTopSalesNPurchaseBranches]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.getTopSalesNPurchaseBranches]
	@CompanyId INT
	--@FROM DATE,
	--@TO DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	DECLARE @salesID INT = 2,
			@purchaseId INT = 1
			                                                                                 
	SELECT TOP 10 coalesce(SUM(SO.NetTotal),0) AS NetTotal,reportId = @salesID,B.BranchName
	FROM [stk.SalesOrder] SO
	INNER JOIN [msd.Branch] B ON B.BranchId = SO.ShipLocationId
	--WHERE  CONVERT(varchar(10),SO.CreatedDateTime,111) = CONVERT(VARCHAR(10), getdate(), 111)
	WHERE CAST(SO.CreatedDateTime AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND CAST(GETDATE() AS DATE)
	GROUP BY BranchName
	ORDER BY NetTotal DESC 

	SELECT TOP 10 coalesce(SUM(PO.NetTotal),0) AS NetTotal,reportId = @purchaseId,B.BranchName
	FROM [stk.PurchaseOrder] PO
	INNER JOIN [msd.Branch] B ON B.BranchId = PO.ShipLocationId
	--WHERE  CONVERT(varchar(10),PO.CreatedDateTime,111) = CONVERT(VARCHAR(10), getdate(), 111)
	WHERE CAST(PO.CreatedDateTime AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND CAST(GETDATE() AS DATE)
	GROUP BY BranchName
	ORDER BY NetTotal DESC 

END
GO
