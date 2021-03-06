USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetPaymentHistoryDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetPaymentHistoryDetails]
(
@PageId INT,
@BusinessPartnerId INT,
@BusinessPartnerTypeId SMALLINT
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE 
	        @RowsPage SMALLINT=500,
			@TotalRecordCount INT = 0 ;

	 --IF ( @DocumentNo <>  'NULL' )
	 --    BEGIN
  --           SELECT 
		--		PD.Id,
		--		PD.DocumentNo,
		--	--	BP.DisplayName AS 'BusinessPartnerName',
		--	--	PD.PaymentTypeId,
		--	--	AU.UserName,
		--		PD.ReferenceNo,
		--	--	PD.BusinessPartnerId,
		--		--( PD. PD.TotalPaid) AS 'Balance',
		--	----	PD.TotalPaid AS 'TotalPaidAmount',
	
		--		CONVERT(varchar, Pd.CreatedDateTime, 100) AS 'Date'
		--		FROM [dbo].[csh.PaymentDetails] PD
		--		INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PD.BusinessPartnerId
		--		INNER JOIN [usm.ApplicationUser] AU ON AU.UserID = PD.CreatedUserId
		--		WHERE PD.DocumentNo = @DocumentNo
		--		ORDER BY PD.Id		    
		-- END
	 IF (@BusinessPartnerId >0)
	  BEGIN

	      SELECT 
		  @TotalRecordCount =  COUNT (  PD.Id) 	
		  FROM [dbo].[csh.PaymentDetails] PD
		  INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PD.BusinessPartnerId
		  WHERE PD.BusinessPartnerId = @BusinessPartnerId AND PD.PaymentTypeId = @BusinessPartnerTypeId
		 

	      
		SELECT 
		PD.Id,
		@TotalRecordCount,
		PD.DocumentNo,
		BP.DisplayName AS 'BusinessPartnerName',
		PD.PaymentTypeId,
		AU.UserName,
		PD.ReferenceNo,
		PD.BusinessPartnerId,
		--( PD. PD.TotalPaid) AS 'Balance',
		PD.TotalPaid AS 'TotalPaidAmount',
	
		CONVERT(varchar, Pd.CreatedDateTime, 100) AS 'Date'
		FROM [dbo].[csh.PaymentDetails] PD
		INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PD.BusinessPartnerId
		INNER JOIN [usm.ApplicationUser] AU ON AU.UserID = PD.CreatedUserId
		WHERE PD.BusinessPartnerId = @BusinessPartnerId AND PD.PaymentTypeId = @BusinessPartnerTypeId
		ORDER BY PD.Id
	  END
	ELSE
	BEGIN

	     SELECT 
		  @TotalRecordCount =  COUNT (  PD.Id) 	
		  FROM [dbo].[csh.PaymentDetails] PD
		  INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PD.BusinessPartnerId
           WHERE  PD.PaymentTypeId = @BusinessPartnerTypeId	
		   

	    SELECT 
		PD.Id,
		@TotalRecordCount AS 'TotalRecordCount',
		PD.DocumentNo,
		BP.DisplayName AS 'BusinessPartnerName',
		PD.PaymentTypeId,
		AU.UserName,
		PD.ReferenceNo,
		PD.BusinessPartnerId,
		PD.TotalPaid AS 'TotalPaidAmount',
		CONVERT(varchar, Pd.CreatedDateTime, 100) AS 'Date'
		FROM [dbo].[csh.PaymentDetails] PD
		INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PD.BusinessPartnerId
		INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserID = PD.CreatedUserId
		WHERE  PD.PaymentTypeId = @BusinessPartnerTypeId
		ORDER BY PD.Id
		OFFSET ((@PageId - 1) * @RowsPage) ROWS
		FETCH NEXT @RowsPage ROWS ONLY;
	END
END
GO
