USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockAdjusmentSummeryByBranchId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockAdjusmentSummeryByBranchId]
(
	@BranchId SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

	
    SELECT 
	
	SAS.id,
	SAS.StockAdjustmentId,
	SAS.CreatedDateTime AS 'CreatedDate',
	SAS.CreatedUserId,
	SAS.BranchID,
	B.BranchName
	FROM [stk.StockAdjustmentSummery] SAS
	INNER JOIN [msd.Branch] B ON B.BranchId = SAS.BranchID
   -- INNER JOIN [msd.ApplicationUserLogInDetails] LD ON LD.UserId = STA.CreatedUserId
	 where SAS.BranchID = @BranchId
	 
END
GO
