USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockAdjustmentDetailByAdjusmentId]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockAdjustmentDetailByAdjusmentId]

@StockAdjustmentId VARCHAR(20)
AS
BEGIN
	SELECT *
	FROM [stk.StockAdjustmentDetails] SAD
	WHERE SAD.StockAdjustmentId = @StockAdjustmentId

END

GO
