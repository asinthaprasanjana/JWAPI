USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockAdjustmentSummery]    Script Date: 01/04/2019 9:46:08 AM ******/
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
	@BranchId INT,
	@CreatedUserId INT
)

	
	
AS
BEGIN	
		
		DECLARE 	@StockAdjusmentId VARCHAR(20),
					@ApprovalStatus   TINYINT,
					@StockAdjusmentApprovalTypeId TINYINT = 3,
					@IsApprovalNeed   TINYINT = 0;  -- default status is approved  

					SELECT @ApprovalStatus = AT.IsActive FROM [wkb.ApprovalTypes] AT
					WHERE AT.ApprovalTypeId = @StockAdjusmentApprovalTypeId

					IF( @ApprovalStatus = 1)
					   BEGIN
					    SET @IsApprovalNeed = 1  -- pending approval needed
					   END
					ELSE
					  BEGIN
					    -- no need approval
					   SET  @IsApprovalNeed = 0    -- set to no need approval
					  END
					    


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
			@IsApprovalNeed,
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
