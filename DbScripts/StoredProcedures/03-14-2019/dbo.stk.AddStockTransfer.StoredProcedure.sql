USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockTransfer]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockTransfer]
	@ID nchar(50),
	@CompanyId int,
	@StockTransferId int,
	@SourceLocationId int,
	@SourceLocationName nvarchar(30),
	@DestinationLocationId int,
	@DestionationLocationName nvarchar(30),
	@CreatedUserId int,
	@CreatedDateTime datetime

	
	
AS
BEGIN
		INSERT INTO stk.StockTransfers
		(
			Id,
			CompanyID,
			StockTransferId,
			SourceLocationId,
			SourceLocationName,
			DestinationLocationId,
			DestinationLocationName,
			CreatedUserId,
			CreatedDateTime
		) 
		values 
		( 
				@ID ,
			@CompanyId ,
			@StockTransferId ,
			@SourceLocationId ,
			@SourceLocationName ,
			@DestinationLocationId ,
			@DestionationLocationName,
			@CreatedUserId ,
			@CreatedDateTime  
		)
END
GO
