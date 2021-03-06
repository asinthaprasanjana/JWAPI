USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePartiallyPurchaseOrderRecieve]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdatePartiallyPurchaseOrderRecieve]
(
@PurchaseNo nvarchar(20),
@RecievingId INT,
@PurchaseOrderItemId INT,
@RecievedQuantity FLOAT,
@FreeQuantity FLOAT,
@IsBilling  TINYINT,
@UserId  INT
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PartialyRecievedStatus    TINYINT = 2,
	        @FullyRecievedStatus       TINYINT = 1,-- MultipurposeTag Table
		    @PreviouslyRecievdQuantity FLOAT   = 0,
			@TotalOrderdQuantity       FLOAT   = 0,
			@productId				   INT,
			@TotalQuantity             FLOAT,
			@companyId                 INT =1,
			@UsersBranchId			   INT,
			@recieveTransactionTypeId  TINYINT = 4,
			@ApprovalStatus            TINYINT,
			@ApprovalPendingStatus     TINYINT  = 1,
			@ApprovalRejectedStatus    TINYINT  = 3,
			@ShippingBranchId          INT = 0,
		    @NewlyRecievingQuantity    FLOAT,
			@PurchaseOrderNotIssuedStatus TINYINT = 0 ;


	IF( @RecievedQuantity <1)
	   BEGIN
	     return 0 ;
	   END

	     

	 IF EXISTS ( SELECT 1 FROM  [stk.PurchaseOrderItems] POI
	            INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POI.PurchaseNo
				 WHERE PO.Status = @PurchaseOrderNotIssuedStatus)

				 BEGIN
				   		  RAISERROR('Please Issue The Purchase Order Before Recieve', 16, 1);
						  RETURN 0
				 END


	 IF EXISTS(SELECT 1 FROM [stk.PurchaseOrderRecieved] POR WHERE POR.PurchaseNo= @PurchaseNo)
	    BEGIN

	         IF (@RecievedQuantity <0)
		    BEGIN
			 RAISERROR('Invalid Quantity. Recieve Failed !..', 16, 1);
			END

             SELECT @UsersBranchId = AU.BranchId FROM [msd.ApplicationUserLogInDetails] AU WHERE UserId = @UserId;
   
             IF NOT EXISTS (SELECT 1 FROM [stk.PurchaseOrder] PO WHERE PO.ShipLocationId = @UsersBranchId AND PO.PurchaseNo = @PurchaseNo)
	     BEGIN
		 			    RAISERROR('You can not perform this action. Invalid Branch', 16, 1);
						Return 0;
		 END

		     SELECT @ApprovalStatus = PO.ApprovalStatus FROM [stk.PurchaseOrder] PO WHERE PO.PurchaseNo = @PurchaseNo

			 IF (@ApprovalStatus = @ApprovalPendingStatus)
			     BEGIN
				   RAISERROR('This purchase has not been approved yet', 16, 1);
				   return 0 ;
				 END
			 IF (@ApprovalStatus = @ApprovalRejectedStatus)
			     BEGIN
				   RAISERROR('This purchase has  been rejected', 16, 1);
				   return 0 ;
				 END
          
	         IF NOT EXISTS (SELECT 1 FROM [stk.PurchaseOrder] PO WHERE PO.Recieved = @FullyRecievedStatus AND PO.PurchaseNo = @PurchaseNo)
	            BEGIN
				  
				    IF  EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecieved] POR WHERE POR.PurchaseNo = @PurchaseNo AND POR.PurchaseOrderItemId = @PurchaseOrderItemId AND POR.RecievedQuantity >0)
				       BEGIN
						   SELECT  
						  
						   @PreviouslyRecievdQuantity = POR.RecievedQuantity,
						   @TotalOrderdQuantity       = POR.TotalQuantity
						  
						   FROM [stk.PurchaseOrderRecieved] POR
						   WHERE POR.PurchaseOrderItemId = @PurchaseOrderItemId AND POR.PurchaseNo=@PurchaseNo;
						     						    
				       END
					
				    SELECT  						  
						   @productId = POR.ProductId,
						   @TotalQuantity = POR.TotalQuantity
						   FROM [stk.PurchaseOrderRecieved] POR
						   WHERE POR.PurchaseOrderItemId = @PurchaseOrderItemId AND POR.PurchaseNo=@PurchaseNo;
					 
			        SET  @NewlyRecievingQuantity = @RecievedQuantity + @PreviouslyRecievdQuantity;

					IF(@TotalQuantity < @NewlyRecievingQuantity)
					  BEGIN
					  	 RAISERROR('Recieved quantity is greater than the ordered quantity.Recieve not saved', 16, 1);
					
					  return 0
					  END
			
				   UPDATE 
					[stk.PurchaseOrderRecieved] SET
					RecievedQuantity = @NewlyRecievingQuantity,
					FreeQuantity  = @FreeQuantity
					WHERE  PurchaseNo = @PurchaseNo AND PurchaseOrderItemId = @PurchaseOrderItemId

				   UPDATE [stk.PurchaseOrder] SET
					 Recieved = @PartialyRecievedStatus,
					 LastModifiedDateTime = GETDATE(),
					 LastModifiedUserId = @UserId
					 WHERE PurchaseNo = @PurchaseNo

				  IF NOT EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecievedSummery] WHERE RecievedId = @RecievingId)
				       BEGIN
					     INSERT INTO [stk.PurchaseOrderRecievedSummery]
						  (
						    RecievedId,
							PurchaseNo,
							IsBilled,
							TotalQuantity,
							CreatedUserId,
							CreatedDateTime,
							LastModifiedUserId,
							LastModifiedDateTime
							)
							VALUES
							(
							 @RecievingId,
							 @PurchaseNo,
							 0,
							 @TotalQuantity,
							 @UserId,
							 GETDATE(),
							 @UserId,
							 GETDATE()
							 )
							
					   END

				   INSERT INTO [stk.PurchaseOrderRecievedEvents]
						(   	
							[RecievedId]
						   ,[PurchaseNo]
						   ,[PurchaseOrderItemId]
						   ,[ProductId]
						   ,[RecievedQuantity]
						   ,[TotalQuantity]
						   ,[FreeQuantity]
						   ,[CreatedUserId]
						   ,[CreatedDateTime]
						   )
						   VALUES (
						   @RecievingId,
						   @PurchaseNo,
						   @PurchaseOrderItemId,
						   @ProductId,
						   @RecievedQuantity,
						   @TotalQuantity,
						   @FreeQuantity,
						   @UserId,
						   GETDATE()
						   )

				SELECT @ShippingBranchId= PO.ShipLocationId FROM [stk.PurchaseOrder] PO WHERE PO.PurchaseNo = @PurchaseNo;
				DECLARE @TotalRecieveQuantity INT;

				SET @TotalRecieveQuantity = @FreeQuantity + @RecievedQuantity;

						    INSERT INTO [stk.StockTransactionLogs]
								   (TransactionTypeId,
								    ReferenceNo,
									BranchId,
									ProductId,
									Quantity,
									CreatedUserId,
									CreatedDateTime
									)
									VALUES (
									@recieveTransactionTypeId,
									@PurchaseNo,
									@ShippingBranchId,
									@productId,
									@TotalRecieveQuantity ,
									@UserId,
									GETDATE()
									)

				 IF NOT EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecieved] WHERE PurchaseNo = @PurchaseNo AND RecievedQuantity <> TotalQuantity)
                   BEGIN
				       
	                    UPDATE [stk.PurchaseOrder] SET
						 Recieved = @FullyRecievedStatus
						 WHERE PurchaseNo = @PurchaseNo
				   END
	            			  
				END
			
		       ELSE
	    BEGIN
		 RAISERROR('This Purchase Order is already fully recieved', 16, 1);
		END

	   END

	ELSE 
	 BEGIN
	     RAISERROR('Invalid Purchase Number', 16, 1);

	 END
END

GO
