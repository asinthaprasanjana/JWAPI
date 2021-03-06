USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockTranstions]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockTranstions]
	@ID INT,
	@CompanyId INT,
	@TransactionId CHAR(20),
	@TransactionTypeId INT,
	@QuantityChange INT,
	@CreatedUserId SMALLINT,
	@CreatedDateTime DATETIME

	
	
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
