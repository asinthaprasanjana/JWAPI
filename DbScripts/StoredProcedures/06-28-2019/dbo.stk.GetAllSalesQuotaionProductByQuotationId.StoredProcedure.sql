USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllSalesQuotaionProductByQuotationId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllSalesQuotaionProductByQuotationId]
(
 @QuotationId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	
    SELECT SQP.*, P.ProductName
	FROM [stk.SalesQuotationProducts] SQP
	INNER JOIN [msd_Product] P ON P.ProductId = SQP.ProductID
	WHERE SQP.QuotationID = @QuotationId
END
GO
