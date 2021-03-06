USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockTranferSummeryDetailsBySourceId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockTranferSummeryDetailsBySourceId]
(
 @BranchId SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	
    SELECT *,
			CASE STS.Status 
             WHEN 0 THEN 'Pending'
             WHEN 1 THEN 'Accepted'
			  WHEN 2 THEN 'Rejected'
          END  AS 'StatusType'
	FROM [stk.StockTransferSummeryDetails] STS
	WHERE STS.SourceLocationId = @BranchId
END
GO
