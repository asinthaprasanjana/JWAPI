USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesQuotationSummery]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSalesQuotationSummery]
	
(
	@CompanyID SMALLINT,
	@BusinessPartnerID VARCHAR(50),
	@BusinesspartnerName VARCHAR(50),
	@BranchID SMALLINT,
	@CreatedUserId SMALLINT,
	@GrossTotal FLOAT
)

AS
BEGIN
		DECLARE @LastQuotationId VARCHAR(20),
		        @SalesQuatationApprovalTypeId TINYINT = 7,
				@ApprovalStatus          TINYINT = 0;
		 

		 SELECT @ApprovalStatus = IsActive
		 FROM [wkb.ApprovalTypes] WHERE ApprovalTypeId = @SalesQuatationApprovalTypeId
		INSERT INTO [stk.SalesQuotationSummary]
		(
			CompanyID,
			BusinessPartnerId,
			BuinessPartnerName,
			BranchID,
			AprovalStatus,
			CreatedUserID,
			GrossTotal,
			CreatedDateTime
		) 
		values 
		( 
			
			@CompanyId ,
			@BusinessPartnerID ,
			@BusinesspartnerName ,
			@BranchID ,
			@ApprovalStatus,
			@CreatedUserId ,
			@GrossTotal,
			GETDATE()  
		)

		SELECT @LastQuotationId= SCOPE_IDENTITY() 
		
		SELECT @LastQuotationId AS QuotationId				
		
END
GO
