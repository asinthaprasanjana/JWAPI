USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderById]    Script Date: 07/03/2019 10:02:04 AM ******/
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
@PurchaseNo NVARCHAR(20),
@GrossTotal MONEY,
@Tax    MONEY,   
@Discount  MONEY,
@NetTotal  MONEY,
@UserId INT
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
					@purchaseOrderItemId            INT     = 0,
					@CompanyId						TINYINT = 1;

	                IF EXISTS (SELECT 1 FROM [wkb.ApprovalTypes] AT WHERE AT.ApprovalTypeId = @PurchaseOrderApprovalTypeId AND AT.IsActive = 1)
						   BEGIN 
							 SET @ApprovalStatus =1;
							-- EXEC [dbo].[wkb.AddNewApproveByApprovalId]  @PurchaseOrderApprovalTypeId, @PurchaseNo, @UserId
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

			INSERT INTO [dbo].[stk.PurchaseOrder]
					   ([CompanyId]
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
			SELECT	@LastInsertedPurchaseID = SCOPE_IDENTITY() 

			   SELECT @LastInsertedPurchaseNo = PO.PurchaseNo 			         
			    FROM [stk.PurchaseOrder] PO WHERE PO.Id = @LastInsertedPurchaseID
			
			    INSERT INTO [dbo].[stk.PurchaseOrderItems]
					   (
					   [CompanyId]
					   ,[PurchaseNo]
					   ,[ItemId]
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
					   @LastInsertedPurchaseNo,
					   POD.ItemId,
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
							 TotalQuantity,
							 RecievedQuantity,
							 FreeQuantity,
							 CreatedUserId,
							 CreatedDateTime)
							 SELECT
							 POI.CompanyId,
							 POI.PurchaseNo,
							 POI.Id,
							 POI.ItemId,
							 POI.Quantity,
							 @InitialRecievedQuantity,
							 @InitialRecievedQuantity,
							 POI.CreatedUserId,
							 GETDATE()
							 FROM [stk.PurchaseOrderItems] POI
							 WHERE POI.PurchaseNo = @LastInsertedPurchaseNo

				


                SELECT @LastInsertedPurchaseNo AS 'PurchaseNo' 
			    FROM [stk.PurchaseOrder] PO WHERE PO.Id = @LastInsertedPurchaseID

                 
         --  COMMIT TRANSACTION
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
