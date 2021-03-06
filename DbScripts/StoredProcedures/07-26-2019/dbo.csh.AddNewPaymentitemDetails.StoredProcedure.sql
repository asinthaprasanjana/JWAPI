USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPaymentitemDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.AddNewPaymentitemDetails]
(
  @PayementDocumentNo		 VARCHAR(20),
  @PaidAmount				 DECIMAL,
  @BillId					 INT,
  @PayementMethodTypeId      SMALLINT,
  @PayementType     SMALLINT,
  @Reference1				 VARCHAR(20),
  @Reference2				 VARCHAR(20),
  @Reference3				 VARCHAR(20),
  @Reference4				 VARCHAR(20),
  @CreatedUserId			 SMALLINT
)	
	
	
AS
BEGIN

          DECLARE @AdvancePaymentType SMALLINT = -1,
		          @PreviouslyPaidAmount DECIMAL = 0,
				  @NewPaidAmount        DECIMAL = 0,
				  @BillTotal            DECIMAL = 0,
				  @FullyPaidStatus      TINYINT = 1,
				  @PartiallyPaidStatus  TINYINT = 2,
				  @CustomerPayment      TINYINT = 2,
				  @SupplierPayment      TINYINT = 1,
		          @BusinessPartnerId    INT;

           IF ( @BillId <> @AdvancePaymentType)

		      BEGIN
			 
				     IF ( @PayementType = @SupplierPayment )
				      BEGIN
					     	SELECT
							@PreviouslyPaidAmount = POB.PaidPrice , 
							@BillTotal = POB.TotalPrice
							FROM [csh.PurchaseOrderBilled] POB 
							WHERE POB.Id = @BillId
					  END
				  ELSE IF ( @PayementType = @CustomerPayment)
				     BEGIN
					      SELECT
							@PreviouslyPaidAmount = S.PaidPrice , 
							@BillTotal = S.NetTotal
							FROM [csh.SalesOrderInvoiced] S 
							WHERE S.Id = @BillId
					 END

					 SET @NewPaidAmount = @PreviouslyPaidAmount + @PaidAmount;

					 IF( @NewPaidAmount > @BillTotal)
		               BEGIN
		      			  RAISERROR('You can not pay more than the bill total', 16, 1);
						  RETURN 0
		               END

		        
                     INSERT INTO [csh.PaymentDetailsItems]
					   (
						DocumentNo,
						BillId,
						PaymentMethodTypeId,
						PaidAmount,
						Reference1,
						Reference2,
						Reference3,
						Reference4,
						CreatedUserId,
						CreatedDateTime )
						VALUES 
						(
						  @PayementDocumentNo,
						  @BillId,
						  @PayementMethodTypeId,
						  @PaidAmount,
						  @Reference1,
						  @Reference2,
						  @Reference3,
						  @Reference4,
						  @CreatedUserId,
						  GETDATE()
						)

		             IF ( @PayementType = @SupplierPayment )
				      BEGIN
					      UPDATE  [csh.PurchaseOrderBilled]
							SET PaidPrice = @NewPaidAmount
							WHERE Id = @BillId

						  IF ( @NewPaidAmount > 0 AND @NewPaidAmount < @BillTotal)
								BEGIN
									UPDATE  [csh.PurchaseOrderBilled]
									SET PaymentStatus = @PartiallyPaidStatus
									WHERE Id = @BillId
								END
							ELSE IF ( @NewPaidAmount = @BillTotal )
							   BEGIN
								   UPDATE  [csh.PurchaseOrderBilled]
									SET PaymentStatus = @FullyPaidStatus
									WHERE Id = @BillId
							   END	
					  END
				    ELSE IF ( @PayementType = @CustomerPayment)
				     BEGIN
					      
						  UPDATE [csh.SalesOrderInvoiced]
						         SET PaymentStatus = @PartiallyPaidStatus,
								 PaidPrice = @NewPaidAmount
						          WHERE Id = @BillId

						 
						  IF ( @NewPaidAmount > 0 AND @NewPaidAmount < @BillTotal)
								BEGIN
									UPDATE  [csh.SalesOrderInvoiced]
									SET PaymentStatus = @PartiallyPaidStatus
									WHERE Id = @BillId
								END
							ELSE IF ( @NewPaidAmount = @BillTotal )
							   BEGIN
								   UPDATE  [csh.SalesOrderInvoiced]
									SET PaymentStatus = @FullyPaidStatus
									WHERE Id = @BillId
							   END	
						 
					 END

		     END


 
		  IF ( @BillId  = @AdvancePaymentType )
		       BEGIN
			      DECLARE @AdvancePaymentTypeId SMALLINT = 0,
				          @PaymentTypeId          SMALLINT = 0;
			
			      SELECT @BusinessPartnerId= BusinessPartnerId,
				  @PaymentTypeId = PaymentTypeId							   
				  FROM [csh.PaymentDetails]  
				  WHERE DocumentNo = @PayementDocumentNo

				  IF ( @PaymentTypeId = 8 )
				      BEGIN
					    -- supplier advance  payment type
						SET @AdvancePaymentTypeId = 1;
					  END
				  ELSE
				     BEGIN
					 -- customer advance payment type
					   SET @AdvancePaymentTypeId = 2;
					 END

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
					@PayementMethodTypeId,
					@BusinessPartnerId,
					@PaidAmount,
					@CreatedUserId,
					GETDATE()
						  )
			   END
          

END
GO
