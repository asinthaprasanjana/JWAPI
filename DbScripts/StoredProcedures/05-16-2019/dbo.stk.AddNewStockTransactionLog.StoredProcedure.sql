USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewStockTransactionLog]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddNewStockTransactionLog]
	@TransactionTypeId SMALLINT,
	@BranchId          SMALLINT,
	@RefNo             INT,
	@ProductId         INT,
	@PackSizeId        INT,
	@Quantity          DECIMAL,
	@UserId            SMALLINT

AS
BEGIN
		INSERT INTO [stk.StockTransactionLogs]
					(
						TransactionTypeId,
						ReferenceNo,
						BranchId,
						ProductId,
						PackSizeId,
						Quantity,
						CreatedUserId,
						CreatedDateTime

					)
					VALUES
					 (
						@transactionTypeId,
						@RefNo,
						@BranchId,
						@ProductId,
						@PackSizeId,
						@Quantity,						
						@UserId,
						GETDATE()
					)
END
GO
