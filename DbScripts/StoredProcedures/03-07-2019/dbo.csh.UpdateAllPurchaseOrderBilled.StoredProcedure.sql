USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.UpdateAllPurchaseOrderBilled]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.UpdateAllPurchaseOrderBilled]
(
 @UserId int,
 @PurchaseOrderNo Varchar(20)

)	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PurchaseOrderBilled TINYINT =1;
	IF EXISTS (SELECT 1  FROM[stk.PurchaseOrderItems] WHERE PurchaseNo = @PurchaseOrderNo)
	BEGIN

	BEGIN TRY

	  IF EXISTS (SELECT 1 FROM [stk.PurchaseOrderBilled] WHERE PurchaseOrderNo = @PurchaseOrderNo)
	     BEGIN
		 	  RAISERROR('This Purchase Order has been partially billed', 16, 1);

		 END

	BEGIN TRANSACTION
	INSERT INTO [stk.PurchaseOrderBilled]
        (   
		    [CompanyId]
            ,[PurchaseOrderNo]
          -- ,[PurchaseOrderItemId]
         --  ,[ProductId]
         --  ,[RecievedQuantity]
           ,[CreatedUserId]
           ,[CreatedDateTime]
		   )

(
	   SELECT	
	       POI.CompanyId,
		   POI.PurchaseNo,
		--   POI.Id,
		--   POI.ItemId,
		--   POI.Quantity,
		   @UserId,
		   GETDATE()
		   FROM [stk.PurchaseOrderItems] POI 
		   WHERE POI.PurchaseNo = @PurchaseOrderNo
		  );

		UPDATE [stk.PurchaseOrder]
		SET 
		Billed = @PurchaseOrderBilled,
		LastModifiedUserId = @UserId,
		LastModifiedDateTime = GETDATE();
		      
		COMMIT TRANSACTION
		END TRY
		BEGIN CATCH

		ROLLBACK TRANSACTION
		END CATCH

		  -- SELECT *
		  -- FROM [dbo].[stk.PurchaseOrderRecieved] POR WHERE POR.[PurchaseOrderId] =@PurchaseOrderId
		 

	
	END
	ELSE
	BEGIN 
	  RAISERROR('This Purchase Order Details Does Not Exists!', 16, 1);
	END
END
GO
