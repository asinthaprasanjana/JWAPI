USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockAdjustmentReason]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockAdjustmentReason]
	@Id int,
	@ComapanyId int,
	@ReasonID int,
	@ReasonName nvarchar(30),
	@CreatedUserId SMALLINT,
	@CreatedDateTime datetime
AS
BEGIN
		INSERT INTO stk.StockAdjustmentReasonDetails
		(
			Id,
			ComapanyId,
			ReasonId,
			ReasonName,
			CreatedUserId,
			CreatedDateTime
		) 
		values 
		( 
			@Id ,
			@ComapanyId,
			@ReasonID ,
			@ReasonName ,
			@CreatedUserId ,
			@CreatedDateTime 	 	  
		)
END
GO
