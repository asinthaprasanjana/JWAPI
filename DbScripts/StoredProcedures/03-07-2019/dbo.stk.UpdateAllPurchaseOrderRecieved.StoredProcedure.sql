USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateAllPurchaseOrderRecieved]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateAllPurchaseOrderRecieved]
(
 @UserId int,
 @PurchaseOrderNo Varchar(20)

)	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @PurchaseOrderRecieved TINYINT =1;
	IF EXISTS (SELECT 1  FROM[stk.PurchaseOrderItems] WHERE PurchaseNo = @PurchaseOrderNo)
	BEGIN

	BEGIN TRY

	  IF EXISTS (SELECT 1 FROM [stk.PurchaseOrderRecieved] WHERE PurchaseNo = @PurchaseOrderNo)
	     BEGIN
		 	  RAISERROR('This Purchase order has been partially recieved', 16, 1);

		 END

	BEGIN TRANSACTION
	INSERT INTO [stk.PurchaseOrderRecieved]
        (   		   
            [PurchaseNo]
           ,[PurchaseOrderItemId]
           ,[ItemId]
           ,[RecievedQuantity]
           ,[CreatedUserId]
           ,[CreatedDateTime]
		   )

(
	   SELECT	      
		   POI.PurchaseNo ,
		   POI.Id,
		   POI.ItemId,
		   POI.Quantity,
		   @UserId,
		   GETDATE()
		   FROM [stk.PurchaseOrderItems] POI 
		   WHERE POI.PurchaseNo = @PurchaseOrderNo
		  );

		UPDATE [stk.PurchaseOrder]
		SET 
		Recieved = @PurchaseOrderRecieved,
		LastModifiedUserId = @UserId,
		LastModifiedDateTime = GETDATE()
		WHERE PurchaseNo = @PurchaseOrderNo;
		      
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
