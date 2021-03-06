USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecievedDetailsByCompanyId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecievedDetailsByCompanyId]
	(
	  @CompanyId INT,
	  @Status    TINYINT,
	  @RecievedTypeId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @PurchaseRecieveTransactionTypeId INT = 4;
	SELECT  POS.RecievedId,
	   POS.PurchaseNo,
	   AUL.UserName,
	  CASE POS.[IsBilled] 
           WHEN 1 THEN 'Billed'
           WHEN 0 THEN 'Pending'
		   END AS Status,
		     CASE POS.[IsBilled] 
           WHEN 1 THEN POS.LastModifiedDateTime
           WHEN 0 THEN POS.CreatedDateTime
		   END AS CreatedDateTime		  
	FROM [dbo].[stk.PurchaseOrderRecievedSummery] POS
	INNER JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = POS.CreatedUserId
	ORDER BY  POS.RecievedId DESC 


END
GO
