USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockAdjustmentReasonByCompanyID]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockAdjustmentReasonByCompanyID]
(

 @CompanyID INT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
		SAR.id,
		SAR.ReasonId,
		SAR.ReasonName,
		SAR.CreatedUserId,
		SAR.CreatedDateTime
	FROM [stk.StockAdjustmentReasonDetails] SAR
	where SAR.CompanyId=@CompanyID
END 
GO
