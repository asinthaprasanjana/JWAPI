USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateFullyPurchaseOrderRecieveAndBill]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateFullyPurchaseOrderRecieveAndBill]
(
@PurchaseNo nvarchar(20),
@IsFullyRecieving TINYINT,
@IsFullyBilling TINYINT,
@RecievedId     INT,
@UserId INT
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PartialyRecievedStatus		 TINYINT = 2,
	        @FullyRecievedStatus		 TINYINT = 1,-- MultipurposeTag Table
			@FullyBilledStatus			 TINYINT = 1,
			@PartiallyBilledStatus       TINYINT = 1,
		    @PreviouslyRecievdQuantity   FLOAT,
			@productId				     INT,
			@TotalQuantity               FLOAT,
			@companyId					 INT      =1,
			@ApprovalStatus				 TINYINT,
			@ApprovalPendingStatus		 TINYINT = 1,
			@ApprovalRejectedStatus		 TINYINT = 3,
			@UsersBranchId				 INT,
			@recieveTransactionTypeId    TINYINT  = 4,
			@ShippingBranchId            INT      = 0,
			@PurchaseOrderNotIssuedStatus TINYINT = 0,
		    @NewlyRecievingQuantity		 FLOAT;

   

	 IF EXISTS ( SELECT 1 FROM  [stk.PurchaseOrderItems] POI
	            INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POI.PurchaseNo
				 WHERE PO.Status = @PurchaseOrderNotIssuedStatus AND POI.PurchaseNo = @PurchaseNo)

				 BEGIN
				   		  RAISERROR('Please Issue  The Purchase Order Before Recieve', 16, 1);
						  RETURN 0

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
	         IF(@IsFullyRecieving =1)
	           BEGIN 
		   IF EXISTS( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND  Recieved = @FullyRecievedStatus)
		      BEGIN
			    RAISERROR('This Purchase order has been already fully recieved', 16, 1);
				return 0

			  END

			IF EXISTS( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND  Recieved = @PartialyRecievedStatus)
		      BEGIN
			    RAISERROR('This Purchase order has been partially recieved', 16, 1);

			  END
		  ELSE 
		    BEGIN

			    DECLARE 
				        @StockRecieveTransactionTypeId  INT     = 4,  -- refer [stk.TransactionTypes] table
						@TempPOTableRowCount            INT     = 0,
						@CurrentRowNumber               INT     = 1,
				        @DefaultFreeQuantity			TINYINT = 0;

			    UPDATE [stk.PurchaseOrder] SET 
			         Recieved = @FullyRecievedStatus,
					 LastModifiedUserId = @UserId,
					 LastModifiedDateTime = GETDATE()					 
			         WHERE PurchaseNo = @PurchaseNo

			    DECLARE  @tempPOTable TABLE ( Id int Identity(1,1), purchaseOrderItemId int ,productId int, orderedQuantity float )  

			    INSERT INTO @tempPOTable 
				      (purchaseOrderItemId,
					   productId,
					   orderedQuantity
					  ) 
					  (
					    SELECT 
					    POI.Id,
						POI.ItemId,
					    POI.Quantity
						FROM [stk.PurchaseOrderItems] POI WHERE POI.PurchaseNo = @PurchaseNo
						)
           
		    
			    SELECT @TempPOTableRowCount =  COUNT( TT.purchaseOrderItemId) FROM @tempPOTable TT

				WHILE @CurrentRowNumber <= @TempPOTableRowCount
				   BEGIN

						 DECLARE 
						 @PurchaseOrderItemId INT,
						 @Quantity            FLOAT,
						 @ProductIdNumber     INT

						 SELECT 
						 @PurchaseOrderItemId = TT.purchaseOrderItemId,
						 @Quantity            =TT.orderedQuantity
						 FROM @tempPOTable TT WHERE Id = @CurrentRowNumber

						 IF EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecieved]  POR
						 WHERE POR.PurchaseOrderItemId = @PurchaseOrderItemId AND POR.PurchaseNo=@PurchaseNo AND POR.RecievedQuantity <=0)
						  BEGIN

						     SELECT @TotalQuantity = COUNT ( POI.Id) from [stk.PurchaseOrderItems] POI WHERE POI.PurchaseNo = @PurchaseNo

						  	 UPDATE [stk.PurchaseOrderRecieved]
					         SET RecievedQuantity     = @Quantity,
						     FreeQuantity         = @DefaultFreeQuantity,
						     LastModifiedUserId   = @UserId,
						     LastModifiedDateTime = GETDATE()			      
					        WHERE PurchaseNo = @PurchaseNo AND PurchaseOrderItemId = @PurchaseOrderItemId

					         IF NOT EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecievedSummery] WHERE RecievedId = @RecievedId)
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
										 @RecievedId,
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
											(
											  SELECT

											  @RecievedId,
											  @PurchaseNo,
											  T.purchaseOrderItemId,
											  T.productId,
											  T.orderedQuantity,
											  T.orderedQuantity,
											  @DefaultFreeQuantity,
											  @UserId,
											  GETDATE()
											  FROM @tempPOTable T
											  WHERE T.purchaseOrderItemId = @PurchaseOrderItemId
										   )
							  SELECT @ShippingBranchId= PO.ShipLocationId FROM [stk.PurchaseOrder] PO WHERE PO.PurchaseNo = @PurchaseNo

							  INSERT INTO [stk.StockTransactionLogs]
								   (TransactionTypeId,
								    ReferenceNo,
									BranchId,
									ProductId,
									Quantity,
									CreatedUserId,
									CreatedDateTime
									)
									 (
									SELECT

											  @recieveTransactionTypeId,
											  @PurchaseNo,
											  @ShippingBranchId,
											  T.productId,
											  T.orderedQuantity,										
											  @UserId,
											  GETDATE()
											  FROM @tempPOTable T
											  WHERE T.purchaseOrderItemId = @PurchaseOrderItemId
									)


					  
						  
						   
					   SET @CurrentRowNumber = @CurrentRowNumber +1
				   END

			    END

		  
		    END
	  IF(@IsFullyBilling =1)
	     BEGIN 
		   IF EXISTS( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND  Billed = @FullyBilledStatus OR Recieved = @PartialyRecievedStatus)
		      BEGIN
			    RAISERROR('This Purchase order has been already fully /partially billed', 16, 1);

			  END
		 END
END
END

GO
