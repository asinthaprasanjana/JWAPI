USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockAdjustmentSummery]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockAdjustmentSummery]
(
	@CompanyId INT,
	@BranchId SMALLINT,
	@CreatedUserId SMALLINT
)

	
	
AS
BEGIN	
		
		DECLARE 	@StockAdjusmentId VARCHAR(20),
					@ApprovalStatus   TINYINT = 0,
					@StockAdjusmentApprovalTypeId TINYINT = 3;

					SELECT @ApprovalStatus = AT.IsActive FROM [wkb.ApprovalTypes] AT
					WHERE AT.ApprovalTypeId = @StockAdjusmentApprovalTypeId

					
					    


		INSERT INTO [stk.StockAdjustmentSummery]
		(
			
			CompanyId,
			BranchId,
			ApprovalStatus,
			CreatedUserId,
			CreatedDateTime
		) 
		values ( 
			@CompanyId ,
			@BranchId,
			@ApprovalStatus,
			@CreatedUserId ,
			GETDATE()	  
		)

		SELECT @StockAdjusmentId= SCOPE_IDENTITY()
		
		SELECT  @StockAdjusmentId as StockAdjustmentId,
				SAS.CreatedDateTime as CreatedDate,
				B.BranchName,
				SAS.BranchID

		FROM [stk.StockAdjustmentSummery] SAS
		INNER JOIN [msd.Branch] B ON SAS.BranchID = B.BranchId
		WHERE SAS.StockAdjustmentId = @StockAdjusmentId
END
GO
