USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.UpdateBusinessPartner]    Script Date: 30/05/2019 11:36:25 AM ******/
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
	@BankName varchar,
	@BusinessPartnerTypeId int,
	@BusinessPartnerId int,
	@Addressing varchar(10),
	@FirstName varchar(20),
	@LastName varchar(20),
	@CompanyName varchar(50),
	@CompanyOwner varchar(50),
	@CompanyCode int,
	@City varchar(20),
	@Province varchar(20),
	@DisplayName varchar(50),
	@Address1 varchar(50),
	@Address2 varchar(50),
	@Address3 varchar(50),
	@Email varchar(50),
	@MobileNo int,
	@LandPhoneNo int,
	@CreatedUserId SMALLINT,
	@Description varchar(100),
	@Country varchar(20),
	@BankId int,
	@BranchName varchar(20),
	@AccountNo int,
	@BrcNo int,
	@NIC varchar(12),
	@VatRegNo int,
	@DiscountRate int,
	@CreditPeriod int,
	@RegisteredAs varchar(20)
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
		  NIC=@NIC,
		  Email =@Email,
		  City=@City,
		  Province=@Province,
		  MobileNo =@MobileNo,
		  Description= @Description,
		  Country= @Country,
		  LandPhoneNo= @LandPhoneNo,
		  LastModifiedUserId= @CreatedUserId,
		  LastModifiedDateTime= @CreatedUserId
		WHERE  BusinessPartnerID=@BusinessPartnerId


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
