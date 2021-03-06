USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderById]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdatePurchaseOrderById]
(
@PurchaseNo VARCHAR(20),
@GrossTotal MONEY,
@Tax    MONEY,   
@QcAvailable TINYINT,
@Discount  MONEY,
@NetTotal  MONEY,
@UserId SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS( SELECT ID FROM  [stk.PurchaseOrderDraftDetails]  Where PurchaseNo = @PurchaseNo)
	    BEGIN TRY

			DECLARE @LastInsertedPurchaseID			INT,
		            @LastInsertedPurchaseNo			NVARCHAR(30),
					@ErrorMessage					NVARCHAR(200),
					@ErrorSeverity					INT,  
					@ErrorState						INT,
					@PurchaseOrderApprovalTypeId	TINYINT = 1,
					@ApprovalStatus					TINYINT = 0,
					@InitialRecievedQuantity		TINYINT = 0,
					@InitialBilledPrice             MONEY = 0,
					@InitialBilledQuantity          TINYINT = 0,
					@PurchaseOrderItemId            INT     = 0,
					@PurchaseOrderDocumentTypeId    TINYINT = 1,
					@Id                             VARCHAR(20),
					@DocumentNo                     VARCHAR(20),
					@RecieveTypeId                  SMALLINT,
					@purchaseOrderId                INT     = 0,
					@CompanyId						TINYINT = 1;

	                IF EXISTS (SELECT 1 FROM [wkb.ApprovalTypes] AT WHERE AT.ApprovalTypeId = @PurchaseOrderApprovalTypeId AND AT.IsActive = 1)
						   BEGIN 
							 SET @ApprovalStatus =1;
						   END

				   ELSE
						 BEGIN
						 SET @ApprovalStatus = 0;
						 END
;  
			UPDATE [stk.PurchaseOrderDraftDetails] SET
					   GrossTotal = @GrossTotal,
					   Tax = @Tax,
					   Discount= @Discount,
					   NetTotal = @NetTotal,
					   LastModifiedUserId = @UserId
					   WHERE PurchaseNo = @PurchaseNo

				EXEC	 [dbo].[stk.GetDocumentIdByDocumentTypeId] @PurchaseOrderDocumentTypeId, @Id OUTPUT
			    SET @LastInsertedPurchaseNo = @Id



			
			INSERT INTO [dbo].[stk.PurchaseOrder]
					   ([CompanyId]
					    ,[PurchaseNo]
						,[QcAvailable]
					   ,[BranchId]
					   ,[SupplierId]
					   ,[BillLocationId]
					   ,[ShipLocationId]
					   ,[StockDue]
					   ,[PayementDue]
					   ,[CurrencyId]
					   ,[GrossTotal]
					   ,[NetTotal]
					   ,[Tax]
					   ,[Discount]
					   ,[ApprovalStatus]
					   ,[Status]
					   ,[Recieved]
					   ,[Billed]
					   ,[CreditPeriod]
					   ,[Email]
					   ,[Remarks]
					   ,[CreatedUserId]
					   ,[CreatedDateTime]
					   ,[LastModifiedUserId]
					   ,[LastModifiedDateTime])
			   (
					   SELECT
						PO.CompanyId,
						@LastInsertedPurchaseNo,
						@QcAvailable,
						PO.BranchId,
						PO.SupplierId,
						PO.BillLocationId,
						PO.ShipLocationId,
						PO.StockDue,
						PO.PayementDue,
						PO.CurrencyId,
						PO.GrossTotal,
						PO.NetTotal,
						PO.Tax,
						PO.Discount,
						@ApprovalStatus,
						PO.Status,
						PO.Recieved,
						PO.Billed,
						PO.CreditPeriod,
						PO.Email,
						PO.Remarks,
						@UserId,
						GETDATE(),
						@UserId,
						GETDATE()
					   FROM [stk.PurchaseOrderDraftDetails] PO
						WHERE PO.PurchaseNo = @PurchaseNo);
		
			SET @PurchaseOrderId = SCOPE_IDENTITY() 	
			    INSERT INTO [dbo].[stk.PurchaseOrderItems]
					   (
					   [CompanyId]
					    ,[PurchaseId]
					   ,[PurchaseNo]
					   ,[ProductId]
					   ,[ProductName]
					   ,[packSizeId]
					   ,[PackSizeName]
					   ,[Quantity]
					   ,[QuantityAfter]
					   ,[ItemCost]
					   ,[Discount]
					   ,[Tax]
					   ,[TotalCost]
					   ,[Status]
					   ,[CreatedUserId]
					   ,[CreatedDateTime]
					   ,[LastModifiedUserId]
					   ,[LastModifiedDateTime])

					   SELECT				
					   POD.CompanyId,
					   @PurchaseOrderId,
					   @LastInsertedPurchaseNo,
					   POD.ProductId,
					   POD.ProductName,
					   POD.packSizeId,
					   POD.PackSizeName,
					   POD.Quantity,
					   POD.QuantityAfter,
					   POD.ItemCost,
					   POD.Discount,
					   POD.Tax,
					   POD.TotalCost,
					   POD.Status,
					   @UserId,
					  GETDATE(),
					   @UserId,
						 GETDATE()
					   FROM [dbo].[stk.PurchaseOrderItemsDraftDetails]POD
					   WHERE POD.PurchaseNo = @PurchaseNo;

					
				
				INSERT INTO [stk.PurchaseOrderRecieved]
				            (CompanyId,
							 PurchaseNo,
							 PurchaseOrderItemId,
							 ProductId,							
							 PackSizeId,
							 TotalQuantity,
							
							 FreeQuantity,
							 CreatedUserId,
							 CreatedDateTime)
							 SELECT
							 POI.CompanyId,
							 POI.PurchaseNo,
							 POI.Id,
							 POI.ProductId,
							 POI.packSizeId,
							 POI.Quantity,						
							 @InitialRecievedQuantity,
							 POI.CreatedUserId,
							 GETDATE()
							 FROM [stk.PurchaseOrderItems] POI
							 WHERE POI.PurchaseNo = @LastInsertedPurchaseNo


							 IF ( @QcAvailable = 1)
							    BEGIN
								  SET @RecieveTypeId = 2;
								END
							ELSE
							  BEGIN
							    SET @RecieveTypeId = 3;
							  END


			


      
	    END TRY

		BEGIN CATCH 

	--	ROLLBACK TRANSACTION
		 SET @ErrorMessage  = ERROR_MESSAGE()
         SET @ErrorSeverity = ERROR_SEVERITY()
         SET @ErrorState    = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
		END CATCH
    ELSE
     BEGIN
	      RAISERROR('This Purchase Order Details Does Not Exists!', 16, 1);
	 END
END
GO
