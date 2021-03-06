USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetBusinessPartnerDetailsById]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.GetBusinessPartnerDetailsById]
(
    @BSPId INT
 )	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	

	SELECT TOP 1
	BSP.Id,
	BSP.CompanyId,
	BSPBD.BranchName,
	BSPBD.AccountNo,
	BSPB.BankName,
	BSPFD.BrcNo,
	BSPFD.CreditPeriod,
	BSPFD.DiscountRate,
	BSPFD.VatRegNo,
	BSP.BusinessPartnerId,
	BSP.BusinessPartnerTypeId,
	BSP.FirstName,
	BSP.LastName,
	BSP.CompanyName,
	BSP.DisplayName,
	BSP.Address1,
	BSP.Email,
	BSP.MobileNo,
	BSP.Description,
	BSP.CompanyCode,
	BSP.Country,
	BSP.City,
	BSP.Province,
	BSP.Address2,
	BSP.Address3,
	BSP.RegisteredAs,
	BSP.Addressing,
	BSP.LandPhoneNo,
	BSP.CreatedUserId,
	BSP.CreatedDateTime,
	BSP.LastModifiedUserId,
	BSP.LastModifiedDateTime
	FROM [bsp.BusinessPartner]BSP
	LEFT JOIN [bsp.BusinessPartnerBankDetails] BSPBD ON BSPBD.BusinessPartnerId= BSP.BusinessPartnerId
	LEFT JOIN [msd.BusinessPartnerBanks] BSPB ON BSPB.BankId = BSPBD.BankId
	LEFT JOIN [bsp.BusinessPartnerFinancialDetails]BSPFD ON BSPFD.BusinessPartnerId = BSP.BusinessPartnerId
	WHERE BSP.BusinessPartnerId = @BSPId
	
	 
END
GO
