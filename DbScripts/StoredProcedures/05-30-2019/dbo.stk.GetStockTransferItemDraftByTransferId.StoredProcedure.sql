USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockTransferItemDraftByTransferId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockTransferItemDraftByTransferId]
	@TransferId VARCHAR(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	SELECT SI.TransferId,
		SI.ItemId,
		SI.ItemName,
		SI.Quantity,
		SI.PackSizeId,
		PPS.PackSizeName
	from [stk.StockDraftTransfersItem] SI
	INNER JOIN [msd_ProductPackSize] PPS ON PPS.PackSizeId = SI.PackSizeId
	WHERE SI.TransferId = @TransferId

END
GO
