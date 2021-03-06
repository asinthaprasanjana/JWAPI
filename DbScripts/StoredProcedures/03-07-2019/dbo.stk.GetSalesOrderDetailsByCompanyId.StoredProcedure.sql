USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderDetailsByCompanyId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderDetailsByCompanyId]
(
@CompanyId INT
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	   DECLARE  @SalesOrderStatus VARCHAR,
	            @ModuleId            TINYINT = 3;


	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS


	
	SELECT 
	       SO.[SaleNo],
		   (BP.[FirstName] +' '+ BP.[LastName]) AS 'Customer',
		   [NetTotal],
		   MPT.[Name] AS 'Status',
		   CASE SO.[Invoiced] 
             WHEN 1 THEN 'Invoiced'
			 WHEN 2 THEN 'Returned All'
             WHEN 0 THEN 'Pending'
          END  AS 'Invoiced',
		   SO.[CustomerId],
		   CONVERT(VARCHAR(10), SO.[CreatedDateTime], 110)  AS 'CreatedDateTime'
	 FROM [stk.SalesOrder] SO 
	 INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = SO.CustomerId
	 INNER JOIN [msd.MultipurposeTag] MPT ON MPT.[Data] = SO.[Status]
	 WHERE MPT.[ModuleId] = @ModuleId AND SO.CompanyId = @CompanyId
	 ORDER BY SO.[Id] DESC;
	

END
GO
