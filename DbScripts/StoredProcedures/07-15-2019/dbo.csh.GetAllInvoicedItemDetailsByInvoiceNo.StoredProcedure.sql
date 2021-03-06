USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllInvoicedItemDetailsByInvoiceNo]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllInvoicedItemDetailsByInvoiceNo]
(
	@InvoiceNo VARCHAR(20)
)

AS
BEGIN
	 --SET NOCOUNT ON added to prevent extra result sets from
	 --interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
		Prod.ProductName AS 'ItemName',
		SOII.ItemCost,
		SOII.Quantity,
		SOII.Tax,
		SOII.Discount,
		((SOII.ItemCost+(SOII.ItemCost*(SOII.Tax/100)))-(SOII.ItemCost*(SOII.Discount/100)))*SOII.Quantity AS 'TotalPrice',
		SOII.CreatedDateTime
		
	FROM [dbo].[csh.SalesOrderInvoicedItems] SOII
	INNER JOIN [msd_Product] Prod ON SOII.ProductId=Prod.ProductId
	WHERE SOII.InvoiceNo=@InvoiceNo
END 
GO
