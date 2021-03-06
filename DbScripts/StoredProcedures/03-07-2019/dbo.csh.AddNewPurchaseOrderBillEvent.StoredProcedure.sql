USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPurchaseOrderBillEvent]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewPurchaseOrderBillEvent]
(

	@BillId INT,
	@CompanyId INT,
	@RecievingId INT,
	@PurchaseOrderNo NVARCHAR(10),
	@PurchaseOrderItemId INT,
	@ProductId INT,
	@BilledQuantity FLOAT,
	@BilledPrice FLOAT,
	@CreatedUserId INT

)
	
AS
BEGIN

         DECLARE @PurchaseOrderBillPendingStatus    TINYINT = 0,
		         @PurchaseOrderFullyBillStatus      TINYINT = 1,
				 @PurchaseOrderPartiallyBillStatus  TINYINT = 2

	     IF NOT EXISTS(SELECT 1 FROM [stk.PurchaseOrderRecievedEvents] WHERE RecievedId = @RecievingId AND IsBilled = @PurchaseOrderBillPendingStatus AND PurchaseOrderItemId = @PurchaseOrderItemId)
		    BEGIN
			    RAISERROR('This Recieve has been already billed', 16, 1);
				return 0;
			END


		
	INSERT INTO [dbo].[csh.PurchaseOrderBilledEvents]
           ([BillId]
           ,[CompanyId]
           ,[RecievingId]
           ,[PurchaseOrderNo]
           ,[PurchaseOrderItemId]
           ,[ProductId]
           ,[BilledQuantity]
           ,[BilledPrice]
           ,[CreatedUserId]
           ,[CreatedDateTime])

    VAlUES(

			@BillId ,
			@CompanyId,
			@RecievingId,
			@PurchaseOrderNo,
			@PurchaseOrderItemId,
			@ProductId,
			@BilledQuantity,
			@BilledPrice,
		    @CreatedUserId,
			GETDATE()

	      )
		 
	UPDATE [stk.PurchaseOrderRecievedEvents] 
	SET 
	IsBilled = 1,
	LastModifiedDateTime = GETDATE(),
	LastModifiedUserId   = @CreatedUserId
	WHERE RecievedId = @RecievingId AND PurchaseOrderItemId = @PurchaseOrderItemId

	

	 
	
	  

	      IF EXISTS (SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseOrderNo AND Recieved = 1 )
		    BEGIN
			  IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrderRecievedEvents] WHERE PurchaseNo = @PurchaseOrderNo AND IsBilled = 0 )
	           BEGIN
				 UPDATE [stk.PurchaseOrder] 
				 SET Billed = @PurchaseOrderPartiallyBillStatus
				 WHERE PurchaseNo = @PurchaseOrderNo
		       END
			  ELSE
			   BEGIN
			     UPDATE [stk.PurchaseOrder] 
	             SET Billed = @PurchaseOrderFullyBillStatus
		         WHERE PurchaseNo = @PurchaseOrderNo
			   END
			END
		 ELSE 
		   BEGIN
		    UPDATE [stk.PurchaseOrder] 
				 SET Billed = @PurchaseOrderPartiallyBillStatus
				 WHERE PurchaseNo = @PurchaseOrderNo
		   END

			
			
	  
	UPDATE [stk.PurchaseOrderRecievedSummery] 
	SET 
	IsBilled = 1,
	LastModifiedDateTime = GETDATE(),
	LastModifiedUserId   = @CreatedUserId
	WHERE RecievedId = @RecievingId


	
END
GO
