USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllInvoiceDetailsById]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllInvoiceDetailsById]
(
	@Id INT
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
	WHERE SOI.Id=@Id
END 
GO
