USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.UpdateBusinessPartner]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bsp.UpdateBusinessPartner]
	@CompanyId int,
	@BusinessPartnerId int,
	@BusinessPartnerTypeId int,
	@Addressing nvarchar(10),
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@CompanyName nvarchar(50),
	@CompanyCode int,
	@City nvarchar(20),
	@Province nvarchar(20),
	@DisplayName nvarchar(50),
	@Address1 nvarchar(50),
	@Address2 nvarchar(50),
	@Address3 nvarchar(50),
	@Email nvarchar(50),
	@MobileNo int,
	@LandPhoneNo int,
	@CreatedUserId int,
	@Description nvarchar(100),
	@Country nvarchar(20),
	@BankId int,
	@BranchName nvarchar(20),
	@AccountNo int,
	@BrcNo int,
	@VatRegNo int,
	@DiscountRate int,
	@CreditPeriod int,
	@RegisteredAs nvarchar(20),
	@BankName nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [bsp.BusinessPartner]   SET 
		  FirstName=@FirstName,
		  LastName =@LastName,
		  CompanyName=@CompanyName,
		  CompanyCode=@CompanyCode,
		  DisplayName=@DisplayName,
		  Address1=@Address1,
		  Address2=@Address2,
		  Address3=@Address3,
		  Email =@Email,
		  City=@City,
		  Province=@Province,
		  MobileNo =@MobileNo,
		  Description= @Description,
		  Country= @Country,
		  LandPhoneNo= @LandPhoneNo,
		  LastModifiedUserId= @CreatedUserId,
		  LastModifiedDateTime= @CreatedUserId
		WHERE  BusinessPartnerID=@BusinessPartnerID


		UPDATE [bsp.BusinessPartnerBankDetails]   SET 
			BankId= @BankId,
			BranchName=@BranchName,
			AccountNo=@AccountNo
		WHERE  BusinessPartnerID=@BusinessPartnerID

		UPDATE [bsp.BusinessPartnerFinancialDetails]   SET 
			CreditPeriod=@CreditPeriod,
			DiscountRate=@DiscountRate,
			BrcNo=@BrcNo,
			VatRegNo=@VatRegNo
		WHERE  BusinessPartnerID=@BusinessPartnerID

END
GO
