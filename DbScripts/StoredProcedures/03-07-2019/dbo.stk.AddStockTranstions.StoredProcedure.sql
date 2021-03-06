USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockTranstions]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[stk.AddStockTranstions]
	@ID INT,
	@CompanyId INT,
	@TransactionId nchar(20),
	@TransactionTypeId int,
	@QuantityChange INT,
	@CreatedUserId int,
	@CreatedDateTime datetime

	
	
AS
BEGIN
		INSERT INTO stk.StockTransactions
		(
			Id,
			CompanyId,
			TransactionId,
			TransactionTypeId,
			CreatedUserId,
			CreatedDateTime
		) 
		values 
		( 
			@ID ,
			@CompanyId ,
			@TransactionId ,
			@TransactionTypeId ,
			@QuantityChange ,
			@CreatedUserId ,
			@CreatedDateTime 	  
		)
END
GO
