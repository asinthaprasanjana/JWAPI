USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllInvoiceDetailsByInvoiceNo]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllInvoiceDetailsByInvoiceNo]
(
	@InvoiceNo VARCHAR(20)
)

AS
BEGIN
	 --SET NOCOUNT ON added to prevent extra result sets from
	 --interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
		SOI.InvoiceNo,
		BP.DisplayName,
		SOI.InvoiceDate,
		SOI.GrossTotal,
		SOI.NetTotal,
		SOI.TotalTax,
		SOI.TotalDiscounts
		
	FROM [dbo].[csh.SalesOrderInvoiced] SOI
	INNER JOIN [bsp.BusinessPartner] BP ON SOI.CustomerId=BP.BusinessPartnerId
	WHERE SOI.InvoiceNo=@InvoiceNo
END 
GO
