USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderQuatationDetailsById]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderQuatationDetailsById]
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
		   SQ.BuinessPartnerName AS 'BusinessPartnerName',
		   SQ.QuotationID AS 'Id',
		   SQ.BuinessPartnerName AS 'businessPartnerEmail',
		   BP.Email,   
		   SQ.GrossTotal,
		   SQ.AprovalStatus AS 'ApprovalStatus',
		   SQ.QuotationID,
		   AU.UserName
	 FROM  [stk.SalesQuotationSummary] SQ
	 INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = SQ.CreatedUserID
	 INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = SQ.BusinessPartnerId
	 WHERE SQ.QuotationID = @Id
	  

END
GO
