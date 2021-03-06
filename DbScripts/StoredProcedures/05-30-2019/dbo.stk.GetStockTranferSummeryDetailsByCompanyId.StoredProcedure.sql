USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockTranferSummeryDetailsByCompanyId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockTranferSummeryDetailsByCompanyId]
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
	 ST.DestinationLocationName AS 'Destination',
	 ST.SourceLocationName AS 'Source',
	 ST.CreatedDateTime AS 'Date',
	 LD.UserName
	FROM [stk.StockTransfers] ST
	
	INNER JOIN [msd.ApplicationUserLogInDetails] LD ON LD.UserId = ST.CreatedUserId
	where ST.CompanyID =@CompanyId

END
GO
