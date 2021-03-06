USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllPaymentDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllPaymentDetails]
(
@PageId INT,
@BusinessPartnerTypeId SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @RowsPage                           SMALLINT = 300,
	        @MultipurposeTagPaymentTypeModuleId SMALLINT = 11;
	SET NOCOUNT ON;
	SELECT 
	P.Id,
	P.BusinessPartnerId,
	BP.FirstName + ' ' + BP.LastName AS 'BusinessPartnerName',
	P.CreatedUserId,
	P.DocumentNo,
	P.PaymentTypeId,
	AU.UserName AS 'UserName',
	P.TotalPaid AS 'TotalPaidAmount',
	P.ReferenceNo,
	CONVERT(VARCHAR, P.CreatedDateTime, 100) AS 'Date'
	FROM [csh.PaymentDetails] P 
	INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = P.BusinessPartnerId
	INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = P.CreatedUserId
	ORDER BY P.CreatedDateTime ASC

	OFFSET ((@PageId - 1) * @RowsPage) ROWS
    FETCH NEXT @RowsPage ROWS ONLY;
	    
END 
GO
