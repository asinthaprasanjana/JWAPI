USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetTopSaleProducts]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetTopSaleProducts]
	@CompanyId INT
	--@From DATE,
	--@To DATE

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	DECLARE @salesID INT = 2,
			@purchaseId INT = 1
			
	-- interfering with SELECT statements.
	SELECT TOP 10 coalesce(SUM(SOI.TotalCost),0) AS NetTotal,reportId = @salesID,P.ProductName
	FROM [stk.SalesOrderItems] SOI 
	INNER JOIN msd_Product P ON P.ProductId = SOI.ItemId
	WHERE CAST(SOI.CreatedDateTime AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND CAST(GETDATE() AS DATE) AND SOI.CompanyId = @CompanyId
	GROUP BY ProductName

END
GO
