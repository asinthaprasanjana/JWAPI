USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockTransactionDetailsByCompanyId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockTransactionDetailsByCompanyId]
(
 @CompanyId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	

	SET NOCOUNT ON;

	
    SELECT 
	 T.Id,
	 T.TransactionId,
	 CONVERT(VARCHAR(10), T.CreatedDateTime, 110)  AS 'CreatedDateTime',
	 TT.TransactionName,
	 LD.UserName
	FROM [stk.StockTransactions] T
	INNER JOIN [msd.ApplicationUserLogInDetails] LD ON LD.UserId = T.CreatedUserId
	INNER JOIN [stk.TransactionTypes] TT ON TT.TransactionTypeId = T.TransactionTypeId
	WHERE T.CompanyId = @CompanyId
END
GO
