USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockAdjustmentReason]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[stk.AddStockAdjustmentReason]
	@Id int,
	@ComapanyId int,
	@ReasonID int,
	@ReasonName nvarchar(30),
	@CreatedUserId int,
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
