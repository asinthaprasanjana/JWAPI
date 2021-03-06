USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateFullyPurchaseOrderRecieveAndBill]    Script Date: 16/05/2019 12:39:09 PM ******/
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
@PurchaseNo varchar(20),
@IsFullyRecieving TINYINT,
@IsFullyBilling SMALLINT,
@RecievedId     INT,
@UserId SMALLINT,
@RecieveTypeId SMALLINT


)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

              DECLARE @PartialyRecievedStatus		      TINYINT = 2,
	        @FullyRecievedStatus		      TINYINT = 1,-- MultipurposeTag Table
			@FullyBilledStatus			      TINYINT = 1,
			@PartiallyBilledStatus			  TINYINT = 1,
		    @PreviouslyRecievdQuantity        FLOAT,
			@productId						  INT,
			@TotalQuantity                    FLOAT,
			@companyId						  INT      =1,
			@ApprovalStatus					  TINYINT,
			@ApprovalPendingStatus			  TINYINT  = 1,
			@ApprovalRejectedStatus			  TINYINT  = 3,
			@UsersBranchId					  INT,
			@recieveTransactionTypeId		  TINYINT  = 4,
			@ShippingBranchId				  INT      ,
			@PurchaseOrderNotIssuedStatus     TINYINT  = 0,
			@PurchaseRecieveBusinessProcessId TINYINT  = 3,
		    @Branches VARCHAR(150),
			@PurchaseOrderCancelDisableStatus TINYINT  = 3,
			@Result                           TINYINT ,
			@FullyTempRecievedStatus          TINYINT  = 1,
			@OrginalRecieveStatus             TINYINT = 3,
			@TemporaryRecieveStatus           TINYINT = 2,
		    @NewlyRecievingQuantity		      FLOAT;

										   		
   			 SELECT @ShippingBranchId= PO.ShipLocationId FROM [stk.PurchaseOrder] PO WHERE PO.PurchaseNo = @PurchaseNo;

			 EXEC  @Result= [usm.CheckPermissionByUserId] @PurchaseRecieveBusinessProcessId, @ShippingBranchId, @UserId

			 IF ( @Result <=0)			     
			       BEGIN				  
					  RETURN 0
				   END
			 	 				   		       
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

             IF( @RecieveTypeId = 2)
			  BEGIN
			    IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrder] P WHERE P.PurchaseNo = @PurchaseNo AND TempRecieved = @FullyTempRecievedStatus)
					BEGIN
					   RAISERROR('This purchase order already has been temporary fully recieved', 16, 1);
					   Return 0 

					END
	          END
			ELSE
			    BEGIN
				   IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrder] P WHERE P.PurchaseNo = @PurchaseNo AND Recieved = @PartialyRecievedStatus)
						BEGIN
						   RAISERROR('This purchase order already has been partially recieved .Click Partially recieve button to recieve remainning items', 16, 1);
						   Return 0 

						END
				END
		  
		 
		  			         
		     IF EXISTS( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND  Recieved = @FullyRecievedStatus)
		               BEGIN
			             RAISERROR('This Purchase order has been already fully recieved', 16, 1);
				         RETURN  0
			           END

				   
			 IF ( @RecieveTypeId = @OrginalRecieveStatus)
					     BEGIN
						     IF EXISTS( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND QcAvailable = 1 AND TempRecieved <> @FullyRecievedStatus)
								   BEGIN
									  RAISERROR('You have to temporary recieve all products, before the orginal recieve', 16, 1);
									  RETURN  0
								   END
						 END
			 ELSE IF ( @RecieveTypeId = @TemporaryRecieveStatus)
					    BEGIN
						     IF EXISTS( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND QcAvailable = 1 AND TempRecieved = @PartialyRecievedStatus)
							   BEGIN
								  RAISERROR('This Purchase Order already has been partially recieved ( Temporary).   ', 16, 1);
								  RAISERROR('Click Partially Temporary Recieve Button', 16, 1);

								  RETURN  0
							   END							
						END
					

		          
	

			    DECLARE 
				        @StockRecieveTransactionTypeId  INT     = 4,  -- refer [stk.TransactionTypes] table
						@TempPOTableRowCount            INT     = 0,
						@CurrentRowNumber               INT     = 1,
				        @DefaultFreeQuantity			TINYINT = 0;

						IF (@RecieveTypeId =3)
						      BEGIN

						      IF EXISTS( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND QcAvailable=1 AND TempRecieved <> @FullyTempRecievedStatus)
		                             BEGIN
			                               RAISERROR('You can not fully recieve this purchase order, First you need to recieve this temporary', 16, 1);
				                           RETURN 0
									  END
					          UPDATE [stk.PurchaseOrder] SET 
							 Recieved = @FullyRecievedStatus,
							 LastModifiedUserId = @UserId,
							 isCancelled = @PurchaseOrderCancelDisableStatus,
							 LastModifiedDateTime = GETDATE()					 
							 WHERE PurchaseNo = @PurchaseNo
						END
						ELSE IF ( @RecieveTypeId = 2 )
						      BEGIN
								 UPDATE [stk.PurchaseOrder] SET 
								 TempRecieved = @FullyTempRecievedStatus,
								 LastModifiedUserId = @UserId,
								 isCancelled = @PurchaseOrderCancelDisableStatus,
								 LastModifiedDateTime = GETDATE()					 
								 WHERE PurchaseNo = @PurchaseNo
						     END



			    DECLARE  @tempPOTable TABLE ( Id int Identity(1,1), purchaseOrderItemId int ,productId int, orderedQuantity float,PackSizeId INT )  

			    INSERT INTO @tempPOTable 
				      (purchaseOrderItemId,
					   productId,
					   orderedQuantity,
					   PackSizeId
					  ) 
					  (
					    SELECT 
					    POI.Id,
						POI.ItemId,
					    POI.Quantity,
						POI.packSizeId
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

						 
						 IF EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecieved]  POR WHERE POR.PurchaseOrderItemId = @PurchaseOrderItemId AND POR.PurchaseNo=@PurchaseNo  )
						     BEGIN

								 SELECT @TotalQuantity = COUNT ( POI.Id) from [stk.PurchaseOrderItems] POI WHERE POI.PurchaseNo = @PurchaseNo
							
								 IF ( @RecieveTypeId =2)

								   BEGIN
						  			 UPDATE [stk.PurchaseOrderRecieved]
									 SET  TempRecievedQuantity   =@Quantity,
									 FreeQuantity         = @DefaultFreeQuantity,
									 LastModifiedUserId   = @UserId,
									 LastModifiedDateTime = GETDATE()			      
									 WHERE PurchaseNo = @PurchaseNo AND PurchaseOrderItemId = @PurchaseOrderItemId

								  END
								ELSE
									  BEGIN
									  									  --RAISERROR('test aa', 16, 1);

											   UPDATE [stk.PurchaseOrderRecieved]
											 SET  OrginalRecievedQuantity   =@Quantity,
											 FreeQuantity         = @DefaultFreeQuantity,
											 LastModifiedUserId   = @UserId,
											 LastModifiedDateTime = GETDATE()			      
											 WHERE PurchaseNo = @PurchaseNo AND PurchaseOrderItemId = @PurchaseOrderItemId

										 						


											INSERT INTO [stk.StockTransactionLogs]
												(TransactionTypeId,
												ReferenceNo,
												BranchId,
												ProductId,
												PackSizeId,
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
													T.PackSizeId,
													T.orderedQuantity,										
													@UserId,
													GETDATE()
													FROM @tempPOTable T
													WHERE T.purchaseOrderItemId = @PurchaseOrderItemId
												)


									   END
								     	   
								INSERT INTO [stk.PurchaseOrderRecievedEvents]
											(   
										    
												[RecievedId]
											   ,[PurchaseNo]
											   ,[RecievedTypeId]
											   ,[PackSizeId]
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
												  @RecieveTypeId,
												  T.PackSizeId,
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

									
							END
						
						

							 SET @CurrentRowNumber = @CurrentRowNumber +1
						 END
				 
	 END
		        
				 
				 			 


 
	  




GO
