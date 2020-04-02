USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockTransfer]    Script Date: 30/05/2019 11:36:25 AM ******/
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
	@ID char(50),
	@CompanyId int,
	@StockTransferId int,
	@SourceLocationId int,
	@SourceLocationName varchar(30),
	@DestinationLocationId int,
	@DestionationLocationName varchar(30),
	@CreatedUserId smallint,
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
