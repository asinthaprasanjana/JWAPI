USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.DeleteStockTransferItemDraftById]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.DeleteStockTransferItemDraftById]
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE [stk.StockDraftTransfersItem] 
	from [stk.StockDraftTransfersItem]
	where id =@Id
END
GO
