USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockAdjustmentDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockAdjustmentDetails]

(
	@StockAdjustmentId VARCHAR(20),
	@ProductId INT,
	@SupplierCode VARCHAR(20),
	@NewQuantity INT,
	@Variance INT,
	@Comment VARCHAR(20),
	@AvailableStock INT,
	@BranchId SMALLINT,
	@CreatedUserId SMALLINT,
	@PackSizeId INT
	
)	
AS
BEGIN
		DECLARE @ProductName NVARCHAR(20),
				@BranchName NVARCHAR(20),
				@status TINYINT = 1, --accepted,
				@transactionType TINYINT = 3, -- refer multipurpose table
				@approvalStatus  TINYINT,
				@NoApprovalNeedStatus TINYINT = 0,
				@ApprovedStatus       TINYINT = 2;


		--get Product Name
		SELECT @ProductName = P.ProductName  
		FROM [msd_Product] P
		WHERE P.ProductId = @ProductId

		--get Branch Name
		SELECT @BranchName = B.BranchName
		FROM  [msd.Branch] B
		WHERE B.BranchId = @BranchId

		INSERT INTO [stk.StockAdjustmentDetails]
		(
			
			StockAdjustmentId,
			ProductId,
			ProductName,
			PackSizeId,
			SupplierCode,
			NewQuantity,
			AvailableStock,
			Variance,
			Comment,
			CreatedDateTime
		) 
		values ( 
			@StockAdjustmentId ,
			@ProductId,
			@ProductName,
			@PackSizeId,
			@SupplierCode,
			@NewQuantity,
			@AvailableStock,
			@Variance,
			@Comment,
			GETDATE()	  
		)


		--SELECT @approvalStatus= SA.ApprovalStatus 
		--FROM  [stk.StockAdjustmentSummery] SA 
		--WHERE SA.StockAdjustmentId = @StockAdjustmentId

		IF EXISTS ( SELECT 1 FROM [stk.StockAdjustmentSummery] SA 
		WHERE SA.StockAdjustmentId = @StockAdjustmentId AND  (( SA.ApprovalStatus = @ApprovedStatus) OR (SA.ApprovalStatus = @NoApprovalNeedStatus)))
		 BEGIN
		       print 'a'
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
			@transactionType,
			@StockAdjustmentId,
			@BranchId,
			@ProductId,
			@PackSizeId,
			@Variance,
			@CreatedUserId,
			GETDATE()
		)
		 END
		ELSE
		 BEGIN
		    print 'b'
		 END

END
GO
