USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewAdvancePayment]    Script Date: 26/07/2019 10:10:01 AM ******/
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

	
END
GO
