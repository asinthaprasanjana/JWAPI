USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderQuatationProductsDetailsById]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderQuatationProductsDetailsById]
(
@Id VARCHAR(20)

)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS


	SELECT TOP 1
		   SQP.ProductID AS 'ProductId',
		   SQP.Quantity,
		   SQP.totalCost AS 'TotalCost',
		   SQP.UnitPrice AS 'ItemCost'
	 FROM  [stk.SalesQuotationProducts] SQP
	 WHERE SQP.QuotationID = @Id
	  

END
GO
