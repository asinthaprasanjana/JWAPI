USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePartiallyPurchaseOrderRecieve]    Script Date: 16/05/2019 12:39:09 PM ******/
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
@PurchaseNo VARCHAR(20),
@RecievingId INT,
@PurchaseOrderItemId INT,
@ReturningQuantity INT,
@RecievedQuantity FLOAT,
@FreeQuantity FLOAT,
@IsBilling  TINYINT,
@UserId  SMALLINT,
@RecievedTypeId SMALLINT

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
			@PackSizeId                INT,
			@TotalQuantity             FLOAT,
			@companyId                 INT =1,
			@UsersBranchId			   INT,
			@recieveTransactionTypeId  TINYINT = 4,
			@ApprovalStatus            TINYINT,
			@ApprovalPendingStatus     TINYINT  = 1,
			@ApprovalRejectedStatus    TINYINT  = 3,
			@ShippingBranchId          INT = 0,
			@TemporaryRecieveStatus    SMALLINT = 2,
			@OrgianlRecieveStatus      SMALLINT = 3,
		    @NewlyRecievingQuantity    FLOAT,
			@PurchaseOrderCancelDisableStatus TINYINT = 3,
			@PurchaseOrderNotIssuedStatus TINYINT = 0 ,
			@PurchaseRecieveBusinessProcessId TINYINT  = 3,
			@Result                           TINYINT ;


			 SELECT @ShippingBranchId= PO.ShipLocationId FROM [stk.PurchaseOrder] PO WHERE PO.PurchaseNo = @PurchaseNo;

			 EXEC  @Result= [usm.CheckPermissionByUserId] @PurchaseRecieveBusinessProcessId, @ShippingBranchId, @UserId

			 IF ( @Result <=0)			     
			       BEGIN				  
					  RETURN 0
				   END

	        IF( @RecievedQuantity <=0 AND @FreeQuantity<=0)
	         BEGIN	   				   
	           return 0 ;
	        END

	     
			 IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrder] PO
						 WHERE PO.Status = @PurchaseOrderNotIssuedStatus AND PO.PurchaseNo = @PurchaseNo)
						 BEGIN
				   				  RAISERROR('Please Issue The Purchase Order Before Recieve', 16, 1);
								  RETURN 0
						 END

			
		     SELECT @ApprovalStatus = PO.ApprovalStatus FROM [stk.PurchaseOrder] PO WHERE PO.PurchaseNo = @PurchaseNo

			 IF (@ApprovalStatus = @ApprovalPendingStatus)
			     BEGIN
				   RAISERROR('This purchase has not been approved yet', 16, 1);
				   RETURN 0 ;
				 END
			 IF (@ApprovalStatus = @ApprovalRejectedStatus)
			     BEGIN
				   RAISERROR('This purchase has  been rejected', 16, 1);
				   RETURN 0 ;
				 END

			 IF ( @RecievedTypeId = @OrgianlRecieveStatus)
			   BEGIN
			        IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseNo AND QcAvailable =1 AND TempRecieved = 0 )
					   BEGIN
					      RAISERROR('You have to temporary recieve before the orginal recive', 16, 1);					       
					   END					   
			   END
         

	         IF NOT EXISTS (SELECT 1 FROM [stk.PurchaseOrder] PO WHERE PO.Recieved = @FullyRecievedStatus AND PO.PurchaseNo = @PurchaseNo)
	            BEGIN
				  
				  					 				     
				    SELECT  						  
						   @productId = POI.ItemId,
						   @PackSizeId = POI.packSizeId,
						   @TotalQuantity = POI.Quantity
						   FROM [stk.PurchaseOrderItems] POI
						   WHERE POI.Id = @PurchaseOrderItemId AND POI.PurchaseNo=@PurchaseNo;


					DECLARE @PreviousFreeQuantity    INT,
					        @PreviousOrginalQuantity INT,
							@PreviousTempQuantity    INT,
							@PreviousReturningQuantity INT;

					SELECT  
					  @PreviousFreeQuantity    = POR.FreeQuantity,
				      @PreviousOrginalQuantity = POR.OrginalRecievedQuantity,
					  @PreviousTempQuantity    = POR.TempRecievedQuantity,
					  @PreviousReturningQuantity = POR.ReturningQuantity
					 FROM [stk.PurchaseOrderRecieved] POR
					 WHERE PurchaseOrderItemId = @PurchaseOrderItemId AND PurchaseNo = @PurchaseNo
 

                     -- calculate new quatity
				SET @PreviousFreeQuantity = @PreviousFreeQuantity + @FreeQuantity;
				SET @PreviousOrginalQuantity = @PreviousOrginalQuantity + @RecievedQuantity;
				SET @PreviousTempQuantity = @PreviousTempQuantity + @RecievedQuantity
				SET @PreviousReturningQuantity = @PreviousReturningQuantity + @ReturningQuantity

					 
			   

					IF( @RecievedTypeId = @TemporaryRecieveStatus)
					   BEGIN

							    UPDATE [stk.PurchaseOrder] SET
								 TempRecieved = @PartialyRecievedStatus,
								 isCancelled = @PurchaseOrderCancelDisableStatus,
								 LastModifiedDateTime = GETDATE(),
								 LastModifiedUserId = @UserId
								 WHERE PurchaseNo = @PurchaseNo

							    UPDATE [stk.PurchaseOrderRecieved]
								SET  TempRecievedQuantity   = @PreviousTempQuantity,
								FreeQuantity         = @PreviousOrginalQuantity,
								ReturningQuantity = @PreviousReturningQuantity,
								LastModifiedUserId   = @UserId,
								LastModifiedDateTime = GETDATE()			      
								WHERE PurchaseNo = @PurchaseNo AND PurchaseOrderItemId = @PurchaseOrderItemId

					   END
					ELSE IF ( @RecievedTypeId = @OrgianlRecieveStatus)
					  BEGIN

								UPDATE [stk.PurchaseOrder] SET
								 Recieved = @PartialyRecievedStatus,
								 isCancelled = @PurchaseOrderCancelDisableStatus,
								 LastModifiedDateTime = GETDATE(),
								 LastModifiedUserId = @UserId
								 WHERE PurchaseNo = @PurchaseNo

								 					  					      					       

					   			       

							    UPDATE [stk.PurchaseOrderRecieved]
								SET  OrginalRecievedQuantity   = @PreviousOrginalQuantity,
								FreeQuantity         = @PreviousFreeQuantity,
								ReturningQuantity = @PreviousReturningQuantity,
								LastModifiedUserId   = @UserId,
								LastModifiedDateTime = GETDATE()			      
								WHERE PurchaseNo = @PurchaseNo AND PurchaseOrderItemId = @PurchaseOrderItemId

								IF NOT EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecieved] PO WHERE PO.TotalQuantity <> PO.OrginalRecievedQuantity AND PurchaseNo = @PurchaseNo)
								    BEGIN
									    UPDATE [stk.PurchaseOrder] 
										SET Recieved = @FullyRecievedStatus
										WHERE PurchaseNo = @PurchaseNo
									END
					  END
				  

				

				   INSERT INTO [stk.PurchaseOrderRecievedEvents]
						(   	
							[RecievedId]
							,[RecievedTypeId]
						   ,[PurchaseNo]					  
						   ,[packSizeId]
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
						   @RecievedTypeId,
						   @PurchaseNo,						 
						   @PackSizeId,
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
									PackSizeId,
									Quantity,
									CreatedUserId,
									CreatedDateTime
									)
									VALUES (
									@recieveTransactionTypeId,
									@PurchaseNo,
									@ShippingBranchId,
									@productId,
									@PackSizeId,
									@TotalRecieveQuantity ,
									@UserId,
									GETDATE()
									)

	
				END
			
		       ELSE
	    BEGIN
		 RAISERROR('This Purchase Order is already fully recieved', 16, 1);
		END

	   END

	

GO
