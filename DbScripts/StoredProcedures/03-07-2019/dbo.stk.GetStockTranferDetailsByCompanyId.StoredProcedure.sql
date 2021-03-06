USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockTranferDetailsByCompanyId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockTranferDetailsByCompanyId]
(
 @CompanyId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	 DECLARE  @SourceBranch      VARCHAR,
	          @DestinationBranch VARCHAR;

	SET NOCOUNT ON;

	
    SELECT 
	 ST.StockTransferId,
	 ST.DestinationLocationName,
	 ST.SourceLocationName,
	 ST.CreatedDateTime,
	 LD.UserName
	FROM [stk.StockTransfers] ST
	INNER JOIN [msd.ApplicationUserLogInDetails] LD ON LD.UserId = ST.CreatedUserId
	WHERE ST.CompanyId = @CompanyId
END
GO
