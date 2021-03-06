USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateStockTransferItem]    Script Date: 01/04/2019 9:46:08 AM ******/
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
		/*	DECLARE @status TINYINT = 0,
					@transactionTypeId TINYINT = 2,
					@productId INT,
					@productName VARCHAR(20),
					@sourceId INT,
					@sourceName VARCHAR(20),
					@destinationId INT,
					@destinationName VARCHAR(20),
					@quantity INT,
					@createdUserId INT,
					@companyId INT


					SELECT
					    @companyId = S.CompanyID,
						@sourceId = S.SourceLocationId,
						@sourceName = S.SourceLocationName,
						@destinationId = S.DestinationLocationId,
						@destinationName = S.DestinationLocationName,
						@createdUserId = S.CreatedUserId,
						@productId = S.ItemId,
						@productName = S.ItemName,
						@quantity = S.Quantity

				FROM [stk.StockDraftTransfersItem] S
				WHERE S.TransferId = @TransferId */
	
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
						 S.Quantity,
						 @status

						FROM [stk.StockDraftTransfersItem] S
						WHERE S.TransferId = @TransferIdDraft
					
					DELETE FROM [stk.StockDraftTransfersItem]
					WHERE TransferId = @TransferIdDraft


		
END
GO
