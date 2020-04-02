USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockAdjustmentDetailByAdjusmentId]    Script Date: 30/05/2019 11:36:25 AM ******/
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
