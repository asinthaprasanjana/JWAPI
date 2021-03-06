USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewInvoicePayment]    Script Date: 16/05/2019 12:39:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewInvoicePayment]
(

@InvoicePaymentTypeId tinyint,
@BusinessPartnerId int,
@TotalPrice money,
@InvoiceNo varchar(20),
@CreatedUserId smallint,
@AdvancedPaymentAmount money,
@BalanceAmount money,
@isAdvancePayments tinyint,
@isBalanceToAdvance tinyint,
@CashPayment money,
@ChequePayment money,
@AdvancePayment money,
@PaidAmount money
)
	
AS
BEGIN

  --    IF NOT EXISTS (SELECT 1 FROM [msd.ApplicationPages] WHERE RouterLink = @RouterLink)
	--    BEGIN
		
	INSERT INTO [dbo].[csh.InvoicePayment]
           (
            [InvoicePaymentTypeId]
           ,[BusinessPartnerId]
		   ,[InvoiceNo]
           ,[TotalPrice]
		   ,[CashPayment]
		   ,[ChequePayment]
		   ,[AdvancePayment]
		   ,[CreatedUserId]
		   ,[CreatedDateTime]
		   )

    VAlUES(

			  @InvoicePaymentTypeId,
			  @BusinessPartnerId,
			  @invoiceNo,
			  @TotalPrice,
			  @CashPayment,
			  @ChequePayment,
			  @AdvancePayment,
			  @CreatedUserId,
			  GETDATE()
	      )

	Declare @lastId INT
	SELECT @lastId = SCOPE_IDENTITY()

	IF (@isAdvancePayments=1)
	BEGIN
		INSERT INTO [dbo].[csh.AdvancePayment]
		(
			[AdvancePaymentTypeId]
           ,[BusinessPartnerId]
		   ,[PaymentMethodId]
           ,[TotalPrice]
           ,[CreatedUserId]
		   ,[CreatedDateTime]
		)
		VAlUES
		(

			  1,
			  @BusinessPartnerId,
			  0,
			  @AdvancedPaymentAmount*(-1),
			  @CreatedUserId,
			  GETDATE()
	     )

	END


	IF (@isBalanceToAdvance=1)
			BEGIN
			INSERT INTO [dbo].[csh.AdvancePayment]
			(
			[AdvancePaymentTypeId]
           ,[BusinessPartnerId]
		   ,[PaymentMethodId]
           ,[TotalPrice]
           ,[CreatedUserId]
		   ,[CreatedDateTime]
			)
			VAlUES
			(

			  1,
			  @BusinessPartnerId,
			  0,
			  @BalanceAmount,
			  @CreatedUserId,
			  GETDATE()
			)

	END
	 
	 IF(@TotalPrice+@PaidAmount<(SELECT SOI.NetTotal FROM [csh.SalesOrderInvoiced] SOI WHERE SOI.InvoiceNo=@InvoiceNo))
	 BEGIN
		UPDATE [csh.SalesOrderInvoiced]
		SET PaymentStatus = 2
		WHERE id=@InvoiceNo
	 END

	 IF(@TotalPrice+@PaidAmount=(SELECT SOI.NetTotal FROM [csh.SalesOrderInvoiced] SOI WHERE SOI.InvoiceNo=@InvoiceNo))
	 BEGIN
		UPDATE [csh.SalesOrderInvoiced]
		SET PaymentStatus = 1
		WHERE id=@InvoiceNo
	 END

	 IF(@TotalPrice+@PaidAmount>(SELECT SOI.NetTotal FROM [csh.SalesOrderInvoiced] SOI WHERE SOI.InvoiceNo=@InvoiceNo))
	 BEGIN
		RAISERROR('Invalid Payment',16,1)
	 END

		

END
GO
