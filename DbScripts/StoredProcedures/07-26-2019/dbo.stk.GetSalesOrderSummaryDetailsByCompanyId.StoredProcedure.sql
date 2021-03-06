USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderSummaryDetailsByCompanyId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderSummaryDetailsByCompanyId]
(
 @IsApproved SMALLINT,
 @IsInvoiced SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

   BEGIN

         DECLARE @PendingInvoiceStatus SMALLINT = 0

      IF ( @IsApproved =1)
	       BEGIN
		          SELECT 
					SOD.CreatedUserId,
					SOD.Id,
					SOD.SaleNo AS 'SalesDocumentNo' ,
					SOD.NetTotal,
					BP.DisplayName,
					COUNT(PID.Id) AS COUNT,
					convert(varchar(10), SOD.CreatedDateTime, 120) AS CreatedDateTime
					FROM [stk.SalesOrder] SOD
					INNER JOIN [bsp.BusinessPartner] BP ON SOD.CustomerId=BP.BusinessPartnerId 
					INNER JOIN  [stk.SalesOrderItems] PID ON PID.SaleNo= SOD.SaleNo 
					WHERE   SOD.Invoiced= @PendingInvoiceStatus AND ApprovalStatus  IN (0,2)   -- approved and no approval needed status
					GROUP BY SOD.SaleNo,SOD.NetTotal,BP.DisplayName,SOD.CreatedDateTime,SOD.CreatedUserId, SOD.Id
					ORDER BY SOD.CreatedDateTime DESC
		   END
	  ELSE
	     BEGIN
		       SELECT 
					SOD.CreatedUserId,
					SOD.Id,
					SOD.SaleNo AS 'SalesDocumentNo' ,
					SOD.NetTotal,
					BP.DisplayName,
					COUNT(PID.Id) AS COUNT,
					convert(varchar(10), SOD.CreatedDateTime, 120) AS CreatedDateTime
					FROM [stk.SalesOrder] SOD
					INNER JOIN [bsp.BusinessPartner] BP ON SOD.CustomerId=BP.BusinessPartnerId 
					INNER JOIN  [stk.SalesOrderItems] PID ON PID.SaleNo= SOD.SaleNo 
					WHERE   SOD.Invoiced=5
					GROUP BY SOD.SaleNo,SOD.NetTotal,BP.DisplayName,SOD.CreatedDateTime,SOD.CreatedUserId, SOD.Id
					ORDER BY SOD.CreatedDateTime DESC
		 END

   

    END
END
GO
