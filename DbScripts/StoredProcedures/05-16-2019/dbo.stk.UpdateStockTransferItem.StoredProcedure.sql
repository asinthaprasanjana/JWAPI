USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateStockTransferItem]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateStockTransferItem]
	@TransferIdDraft INT,
	@TransferID INT

	
	
AS
BEGIN
	SET NOCOUNT ON;
				DECLARE	@status TINYINT = 0
	
			INSERT INTO [dbo].[stk.StockTransfersItem]
					   (
					   CompanyId
					   ,TransferId
					   ,SourceLocationId
					   ,SourceLocationName
					   ,DestinationLocationId
					   ,DestinationLocationName
					   ,CreatedUserId
					   ,CreatedDateTime
					   ,ItemId
					   ,ItemName
					   ,PackSizeId
					   ,Quantity
					   ,Status
					   )

						SELECT
					     S.CompanyID,
						 @TransferId,
						 S.SourceLocationId,
						 S.SourceLocationName,
						 S.DestinationLocationId,
						 S.DestinationLocationName,
						 S.CreatedUserId,
						 GETDATE(),
						 S.ItemId,
						 S.ItemName,
						 S.PackSizeId,
						 S.Quantity,
						 @status

						FROM [stk.StockDraftTransfersItem] S
						WHERE S.TransferId = @TransferIdDraft
					
					DELETE FROM [stk.StockDraftTransfersItem]
					WHERE TransferId = @TransferIdDraft


		
END
GO
