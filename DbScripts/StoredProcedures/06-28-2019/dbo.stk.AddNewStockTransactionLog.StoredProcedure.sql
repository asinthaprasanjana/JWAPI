USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewStockTransactionLog]    Script Date: 28/06/2019 4:49:03 PM ******/
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

           DECLARE @BaseUnitQuantity FLOAT,
		           @ProductName      VARCHAR(100);
		   
		       SELECT @BaseUnitQuantity= PZ.PackQty FROM [msd_ProductPackSize] PZ WHERE PackSizeId = @PackSizeId;
			   SELECT @ProductName = P.ProductName FROM [msd_Product] P WHERE P.ProductId = @ProductId;

			   SET @BaseUnitQuantity = @BaseUnitQuantity* @Quantity;


		INSERT INTO [stk.StockTransactionLogs]
					(
						TransactionTypeId,
						ReferenceNo,
						BranchId,
						ProductId,
						ProductName,
						PackSizeId,
						Quantity,
						BaseUnitQuantity,
						CreatedUserId,
						CreatedDateTime

					)
					VALUES
					 (
						@transactionTypeId,
						@RefNo,
						@BranchId,
						@ProductId,
						@ProductName,
						@PackSizeId,
						@Quantity,
						@BaseUnitQuantity,
						@UserId,
						GETDATE()
					)
END
GO
