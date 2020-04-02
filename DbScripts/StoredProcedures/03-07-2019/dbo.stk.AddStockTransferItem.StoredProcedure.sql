USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockTransferItem]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockTransferItem]
	@CompanyId int,
	@TransferId VARCHAR,
	@SourceLocationId int,
	@DestinationLocationId int,
	@CreatedUserId int,
	@ItemId int,
	@Quantity int

	
	
AS
BEGIN
		DECLARE @SourceLocationName VARCHAR(30),
				 @DestinationLocationName VARCHAR(30),
				 @ItemName VARCHAR(30),
				 @Id INT,
				 @status INT = 2; -- status for Pending

		 SELECT @SourceLocationName = B.DisplayName FROM [msd.Branch] B
		 WHERE  B.BranchId = @SourceLocationId

		 SELECT @DestinationLocationName = B.DisplayName FROM [msd.Branch] B
		 WHERE  B.BranchId = @DestinationLocationId

		 SELECT @ItemName = P.ProductName  FROM [msd_Product] P
		 WHERE P.ProductId = @ItemId

		INSERT INTO [stk.StockTransfersItem]
		(
			[CompanyID],
			[TransferId],
			SourceLocationId,
			SourceLocationName,
			DestinationLocationId,
			DestinationLocationName,
			CreatedUserId,
			CreatedDateTime,
			ItemId,
			ItemName,
			[Status],
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
			@status,
			@status
		
		)

				SELECT @id= SCOPE_IDENTITY() 
				SELECT * 
				FROM [stk.StockTransfersItem] S
				WHERE s.id = @id

						
END
GO
