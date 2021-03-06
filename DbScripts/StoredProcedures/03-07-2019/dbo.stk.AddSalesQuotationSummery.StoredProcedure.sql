USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesQuotationSummery]    Script Date: 07/03/2019 10:02:04 AM ******/
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
	@CompanyID INT,
	@BusinessPartnerID VARCHAR(50),
	@BusinesspartnerName varchar(50),
	@BranchID INT,
	@CreatedUserId INT,
	@GrossTotal FLOAT
)

AS
BEGIN
		DeCLARE @LastQuotationId VARCHAR(20)
		 
		INSERT INTO [stk.SalesQuotationSummary]
		(
			CompanyID,
			BusinessPartnerId,
			BuinessPartnerName,
			BranchID,
			CreatedUserID,
			GrossTotal,
			CreatedDate
		) 
		values 
		( 
			
			@CompanyId ,
			@BusinessPartnerID ,
			@BusinesspartnerName ,
			@BranchID ,
			@CreatedUserId ,
			@GrossTotal,
			GETDATE()  
		)

		SELECT @LastQuotationId= SCOPE_IDENTITY() 
		
		SELECT @LastQuotationId AS QuotationId, *
		FROM [stk.SalesQuotationSummary] SQS
		WHERE  SQS.Id = @LastQuotationId
END
GO
