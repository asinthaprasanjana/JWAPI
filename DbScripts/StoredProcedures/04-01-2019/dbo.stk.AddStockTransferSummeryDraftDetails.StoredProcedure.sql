USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockTransferSummeryDraftDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockTransferSummeryDraftDetails]
	@CompanyId int,
	@SourceLocationId int,
	@DestinationLocationId int,
	@CreatedUserId int

	
	
AS
BEGIN

           DECLARE @SourceLocation VARCHAR(30),
		           @DestinationLocation VARCHAR(30),
				   @LastTransferId INT

		 SELECT @SourceLocation = B.DisplayName FROM [msd.Branch] B
		 WHERE  B.BranchId = @SourceLocationId

		 SELECT @DestinationLocation = B.DisplayName FROM [msd.Branch] B
		 WHERE  B.BranchId = @DestinationLocationId

		 
		INSERT INTO [stk.StockTransferSummeryDraftDetails]
		(
			
			CompanyID,
			SourceLocationId,
			SourceLocationName,
			DestinationLocationId,
			DestinationLocationName,
			CreatedUserId,
			CreatedDateTime
		) 
		values 
		( 
			
			@CompanyId ,
			@SourceLocationId ,
			@SourceLocation ,
			@DestinationLocationId ,
			@DestinationLocation,
			@CreatedUserId ,
			GETDATE()  
		)

		SELECT @LastTransferId= SCOPE_IDENTITY() 
		
		SELECT @LastTransferId AS TransferId, *
		FROM [stk.StockTransferSummeryDraftDetails] SS
		WHERE  SS.Id = @LastTransferId
END
GO
