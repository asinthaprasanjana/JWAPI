USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateStockTransferSummeryDetailsbyTransferId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateStockTransferSummeryDetailsbyTransferId]
	@TransferId INT,
	@ReceivedUserId INT,
	@Remarks NVARCHAR(50),
	@StockTransferStatus INT

	
	
AS
BEGIN
	SET NOCOUNT ON;
			DECLARE @ReceivedUserName nvarchar(20),
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

				FROM [stk.StockTransfersItem] S
				WHERE S.TransferId = @TransferId


			SELECT @ReceivedUserName = APD.UserName
			FROM [msd.ApplicationUserLogInDetails] APD
			WHERE APD.UserId = @ReceivedUserId

			UPDATE  [dbo].[stk.StockTransferSummeryDetails]
			SET Status = @StockTransferStatus,
				Remarks = @Remarks,
				ReceivedUserId = @ReceivedUserId,
				ReceivedUserName = @ReceivedUserName
			WHERE TransferId = @TransferId


			IF(@StockTransferStatus=1)
				BEGIN
					--log for source	
					INSERT INTO [stk.StockTransactionLogs]
					(
						TransactionTypeId,
						ReferenceNo,
						BranchId,
						ProductId,
						Quantity,
						CreatedUserId,
						CreatedDateTime

					)
					VALUES
					 (
						@transactionTypeId,
						@TransferId,
						@sourceId,
						@ProductId,
						@quantity *(-1),
						@CreatedUserId,
						GETDATE()
					)

					--log for destination	
					INSERT INTO [stk.StockTransactionLogs]
					(
						TransactionTypeId,
						ReferenceNo,
						BranchId,
						ProductId,
						Quantity,
						CreatedUserId,
						CreatedDateTime

					)
					VALUES
					 (
						@transactionTypeId,
						@TransferId,
						@destinationId,
						@ProductId,
						@quantity,
						@CreatedUserId,
						GETDATE()
					)
				END
			
					

			SELECT * ,			
			CASE STS.Status 
             WHEN 0 THEN 'Pending'
             WHEN 1 THEN 'Accepted'
			  WHEN 2 THEN 'Rejected'
          END  AS 'StatusType'
			FROM [stk.StockTransferSummeryDetails]  STS
			WHERE TransferId = @TransferId
	
					   
		
END
GO
