USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewBillPayment]    Script Date: 16/05/2019 12:39:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewBillPayment]
(

@BillPaymentTypeId tinyint,
@BusinessPartnerId int,
@TotalPrice money,
@BillId varchar (50),
@CreatedUserId smallint,
@AdvancedPaymentAmount money,
@BalanceAmount money,
@isAdvancePayments tinyint,
@isBalanceToAdvance tinyint,
@PaidAmount money
)
	
AS
BEGIN

  --    IF NOT EXISTS (SELECT 1 FROM [msd.ApplicationPages] WHERE RouterLink = @RouterLink)
	--    BEGIN
		
	INSERT INTO [dbo].[csh.BillPayment]
           (
            [BillPaymentTypeId]
           ,[BusinessPartnerId]
		   ,[BillId]
           ,[TotalPrice]
           ,[CreatedUserId]
		   ,[CreatedDateTime]
		   )

    VAlUES(

			  @BillPaymentTypeId,
			  @BusinessPartnerId,
			  @BillId,
			  @TotalPrice,
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
	 
	 IF(@TotalPrice+@PaidAmount<(SELECT POB.TotalPrice FROM [csh.PurchaseOrderBilled] POB WHERE POB.Id=@BillId))
	 BEGIN
		UPDATE [csh.PurchaseOrderBilled]
		SET PaymentStatus = 2
		WHERE id=@BillId
	 END

	 IF(@TotalPrice+@PaidAmount=(SELECT POB.TotalPrice FROM [csh.PurchaseOrderBilled] POB WHERE POB.Id=@BillId))
	 BEGIN
		UPDATE [csh.PurchaseOrderBilled]
		SET PaymentStatus = 1
		WHERE id=@BillId
	 END

	 IF(@TotalPrice+@PaidAmount>(SELECT POB.TotalPrice FROM [csh.PurchaseOrderBilled] POB WHERE POB.Id=@BillId))
	 BEGIN
		RAISERROR('Invalid Payment',16,1)
	 END

		

END
GO
