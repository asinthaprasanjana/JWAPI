USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddBusinessPartner]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddBusinessPartner]
	@CompanyId int,
	@BankName varchar,
	@BusinessPartnerTypeId int,
	@Addressing varchar(10),
	@FirstName varchar(20),
	@LastName varchar(20),
	@CompanyName varchar(50),
	@CompanyOwner varchar(50),
	@CompanyCode varchar(25),
	@City varchar(20),
	@Province varchar(20),
	@DisplayName varchar(50),
	@Address1 varchar(50),
	@Address2 varchar(50),
	@Address3 varchar(50),
	@Email varchar(50),
	@MobileNo varchar(20),
	@LandPhoneNo varchar(20),
	@CreatedUserId SMALLINT,
	@Description varchar(100),
	@Country varchar(20),
	@BankId int,
	@BranchName varchar(20),
	@AccountNo varchar(25),
	@BrcNo varchar(25),
	@NIC varchar(12),
	@VatRegNo varchar(25),
	@DiscountRate int,
	@CreditPeriod int,
	@RegisteredAs varchar(20)
AS
BEGIN
	declare @Id INT;
		INSERT INTO [bsp.BusinessPartner]
		(
				CompanyId ,
				RegisteredAs,
				BusinessPartnerTypeId,
				Addressing,
				FirstName,
				LastName ,
				CompanyName ,
				CompanyOwner,
				CompanyCode,
				DisplayName,
				Address1,
				Address2 ,
				Address3,
				NIC,
				City,
				Province,
				Email ,
				MobileNo ,
				Description,
				Country,
				LandPhoneNo ,
				CreatedUserId,
				CreatedDateTime
				 
		) 
		values 
		( 
				@CompanyId ,
				@RegisteredAs,
				@BusinessPartnerTypeId ,
				@Addressing,
				@FirstName ,
				@LastName ,
				@CompanyName ,
				@CompanyOwner,
				@CompanyCode,
				@DisplayName,
				@Address1,
				@Address2,
				@Address3,
				@NIC,
				@City,
				@Province,
				@Email,
				@MobileNo ,
				@Description,
				@Country,
				@LandPhoneNo ,
				@CreatedUserId,
				GETDATE()   	  
		)
		
		set @Id = SCOPE_IDENTITY();
		
		

		INSERT INTO [bsp.BusinessPartnerBankDetails]
		(
			BusinessPartnerId,
			BankId,
			BranchName,
			AccountNo,
			CreatedUserId,
			CreatedDateTime
		)
		VALUES
		(
			(select b.BusinessPartnerId from [bsp.BusinessPartner] b where b.id = @Id ),
			@BankId,
			@BranchName,
			@AccountNo,
			@CreatedUserId,
			GETDATE()
			
		)

			     

		INSERT INTO [bsp.BusinessPartnerFinancialDetails]
		(
			BusinessPartnerId,
			CreditPeriod,
			DiscountRate,
			BrcNo,
			VatRegNo,
			CreatedUserId,
			CreatedDateTime
		)
		VALUES
		(
			(select b.BusinessPartnerId from [bsp.BusinessPartner] b where b.id = @Id ),
			@CreditPeriod,
			@DiscountRate,
			@BrcNo,
			@VatRegNo,
			@CreatedUserId,
			GETDATE()
			
		)

	--	RAISERROR('Test Error', 16, 1);
END
GO
