USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewAdvancePayment]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewAdvancePayment]
(

@AdvancePaymentTypeId tinyint,
@PaymentMethodId int ,
@BusinessPartnerId int,
@TotalPrice money,
@CreatedUserId int

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
