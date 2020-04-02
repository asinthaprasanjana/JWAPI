USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllInvoiceDetailsByCompanyId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllInvoiceDetailsByCompanyId]
(
	@companyId INT
)

AS
BEGIN
	 --SET NOCOUNT ON added to prevent extra result sets from
	 --interfering with SELECT statements.
	SET NOCOUNT ON;

	Select 
		SOI.Id,
		SOI.InvoiceNo,
		BP.DisplayName,
		SOI.NetTotal,
		SOI.InvoiceDate
		
	FROM [dbo].[csh.SalesOrderInvoiced] SOI
	INNER JOIN [bsp.BusinessPartner] BP ON SOI.CustomerId=BP.BusinessPartnerId
	WHERE SOI.CompanyId=@companyId
END 
GO
