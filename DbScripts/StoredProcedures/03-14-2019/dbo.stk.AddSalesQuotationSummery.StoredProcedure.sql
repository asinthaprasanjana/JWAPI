USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesQuotationSummery]    Script Date: 14/03/2019 11:47:02 AM ******/
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
			CreatedDateTime
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
