USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateStockTransferDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateStockTransferDetails]
	@TransferId int
	--@CreatedUserId int

	
	
AS
BEGIN
	SET NOCOUNT ON;
			DECLARE @CreatedUserName nvarchar,
					@StockTrasnferInitialStatus TINYINT = 0, -- refer multipuResponseTags Table
					@LastTransferId VARCHAR(20)
			--SELECT @CreatedUserName = U.userName 
			--FROM	[msd.ApplicationUserLogInDetails] U
			--WHERE U.userId = @CreatedUserId

			INSERT INTO [dbo].[stk.StockTransferSummeryDetails]
					   ([CompanyId]
					   ,[Status]
					   ,[SourceLocationId]
					   ,[SourceLocationName]
					   ,[DestinationLocationId]
					   ,[DestinationLocationName]
					   ,[CreatedUserId]
					   ,[CreatedUserName]
					   ,[CreatedDateTime]
					   )
			   (
					   SELECT
					    STS.CompanyID,
						@StockTrasnferInitialStatus,
						STS.SourceLocationId,
						STS.SourceLocationName,
						STS.DestinationLocationId,
						STS.DestinationLocationName,
						STS.CreatedUserId,
						AUL.UserName,
						GETDATE()
						
					FROM [stk.StockTransferSummeryDraftDetails] STS
					INNER JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId=STS.CreatedUserId  
					WHERE STS.TransferId = @TransferId)

					SELECT @LastTransferId= SCOPE_IDENTITY() 

			

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
						 @LastTransferId,
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
						 @StockTrasnferInitialStatus

						FROM [stk.StockDraftTransfersItem] S
						WHERE S.TransferId = @TransferId



					DELETE FROM [stk.StockTransferSummeryDraftDetails]
					WHERE TransferId = @TransferId

					DELETE FROM [stk.StockDraftTransfersItem]
					WHERE TransferId = @TransferId

					SELECT @LastTransferId as TransferId,* 
					FROM [dbo].[stk.StockTransferSummeryDetails] STS
					WHERE STS.TransferId = @LastTransferId

		
END
GO
