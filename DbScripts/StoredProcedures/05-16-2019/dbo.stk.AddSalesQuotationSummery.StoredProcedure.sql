USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesQuotationSummery]    Script Date: 16/05/2019 12:39:09 PM ******/
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
		
		SELECT @LastQuotationId AS QuotationId, 
				SQS.*,
				LD.UserName,B.BranchName,
				BP.DisplayName as businessPartnerName,
				BP.Email as businessPartnerEmail

		FROM [stk.SalesQuotationSummary] SQS
		INNER JOIN [msd.ApplicationUserLogInDetails] LD ON LD.UserId = SQS.CreatedUserId
		INNER JOIN [msd.Branch] B ON B.BranchId = SQS.BranchID
		INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = SQS.BusinessPartnerId
		WHERE  SQS.Id = @LastQuotationId
END
GO
