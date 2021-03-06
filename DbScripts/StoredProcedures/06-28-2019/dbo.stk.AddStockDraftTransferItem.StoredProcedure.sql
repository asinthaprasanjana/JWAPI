USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockDraftTransferItem]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockDraftTransferItem]
	@CompanyId INT,
	@TransferId INT,
	@SourceLocationId INT,
	@DestinationLocationId INT,
	@CreatedUserId SMALLINT,
	@ItemId INT,
	@Quantity INT,
	@PackSizeId INT

	
	
AS
BEGIN
		DECLARE @SourceLocationName VARCHAR(30),
				 @DestinationLocationName VARCHAR(30),
				 @ItemName VARCHAR(30),
				 @Id INT

		 SELECT @SourceLocationName = B.DisplayName FROM [msd.Branch] B
		 WHERE  B.BranchId = @SourceLocationId

		 SELECT @DestinationLocationName = B.DisplayName FROM [msd.Branch] B
		 WHERE  B.BranchId = @DestinationLocationId

		 SELECT @ItemName = P.ProductName  FROM [msd_Product] P
		 WHERE P.ProductId= @ItemId

		INSERT INTO [stk.StockDraftTransfersItem]
		(
			CompanyID,
			TransferId,
			SourceLocationId,
			SourceLocationName,
			DestinationLocationId,
			DestinationLocationName,
			CreatedUserId,
			CreatedDateTime,
			ItemId,
			ItemName,
			PackSizeId,
			Quantity
		) 
		values 
		( 
			@CompanyId ,
			@TransferId ,
			@SourceLocationId ,
			@SourceLocationName ,
			@DestinationLocationId ,
			@DestinationLocationName,
			@CreatedUserId ,
			GETDATE(),
			@ItemId,
			@ItemName,
			@PackSizeId,
			@Quantity
		)

				SELECT @id= SCOPE_IDENTITY() 
				SELECT * 
				FROM [stk.StockDraftTransfersItem] S
				WHERE s.id = @id

						
END
GO
