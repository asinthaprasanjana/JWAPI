USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewAdvancePayment]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewAdvancePayment]
(

@AdvancePaymentTypeId TINYINT,
@PaymentMethodId INT ,
@BusinessPartnerId INT,
@TotalPrice DECIMAL,
@CreatedUserId SMALLINT

)
	
AS
BEGIN

  --    IF NOT EXISTS (SELECT 1 FROM [msd.ApplicationPages] WHERE RouterLink = @RouterLink)
	--    BEGIN
		
	INSERT INTO [dbo].[csh.AdvancePayment]
           (
            [AdvancePaymentTypeId]
           ,[PaymentMethodId]
           ,[BusinessPartnerId]
           ,[TotalPrice]
           ,[CreatedUserId]
		   ,[CreatedDateTime]
		   )

    VAlUES(

			  @AdvancePaymentTypeId,
			  @PaymentMethodId,
			  @BusinessPartnerId,
			  @TotalPrice,
			  @CreatedUserId,
			  GETDATE()
	      )

		--END
	 -- ELSE
	  --  BEGIN
		--  	RAISERROR('This Page Is Already Exists', 16, 1);

		--END
		--SELECT * FROM [msd.ApplicationPages]
END
GO
