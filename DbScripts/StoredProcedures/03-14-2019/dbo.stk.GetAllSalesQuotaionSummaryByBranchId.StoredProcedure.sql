USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllSalesQuotaionSummaryByBranchId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllSalesQuotaionSummaryByBranchId]
(
 @BranchId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	
    SELECT SQS.*,
			LD.UserName,B.BranchName,
			BP.DisplayName as businessPartnerName,
			BP.Email as businessPartnerEmail


	FROM [stk.SalesQuotationSummary] SQS
	INNER JOIN [msd.ApplicationUserLogInDetails] LD ON LD.UserId = SQS.CreatedUserId
	INNER JOIN [msd.Branch] B ON B.BranchId = SQS.BranchID
	INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = SQS.BusinessPartnerId
	WHERE SQS.BranchID = @BranchId
END
GO
