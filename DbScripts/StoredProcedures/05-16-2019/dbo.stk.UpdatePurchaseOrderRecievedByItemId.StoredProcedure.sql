USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderRecievedByItemId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdatePurchaseOrderRecievedByItemId]
(
 @UserId SMALLINT,
 @PurchaseNo INT,
 @PurchaseOrderItemId INT,
 @ProductId  INT,
 @RecievedQuantity FLOAT,
 @FreeQuantity FLOAT,
 @IsBilling    TINYINT
)	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 DECLARE @PurchaseOrderNotIssuedStatus TINYINT = 0 ;

	 IF EXISTS ( SELECT 1 FROM  [stk.PurchaseOrderItems] POI
	            INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POI.PurchaseNo
				 WHERE PO.Status = @PurchaseOrderNotIssuedStatus)

				 BEGIN
				   		  RAISERROR('Please Issue The Purchase Order Before Recieve', 16, 1);
						  RETURN 0

				 END
				  

	IF EXISTS (SELECT 1 FROM[stk.PurchaseOrderItems] WHERE PurchaseNo = @PurchaseNo)
	BEGIN

	  


	    
	INSERT INTO [stk.PurchaseOrderRecieved]
        (   		   
            [PurchaseNo]
           ,[PurchaseOrderItemId]
           ,[ProductId]
           ,[RecievedQuantity]
           ,[FreeQuantity]
           ,[CreatedUserId]
           ,[CreatedDateTime]
		   )

(
	   SELECT	      
		   POI.PurchaseNo ,
		   POI.Id,
		   @ProductId,
		   @RecievedQuantity,
		   @FreeQuantity,
		   @UserId,
		   GETDATE()
		   FROM [stk.PurchaseOrderItems] POI 
		   WHERE POI.PurchaseNo = @PurchaseNo
		  );

		  -- SELECT *
		  -- FROM [dbo].[stk.PurchaseOrderRecieved] POR WHERE POR.[PurchaseOrderId] =@PurchaseOrderId
		 

	
	END
	ELSE
		BEGIN 
		  RAISERROR('This Purchase Order Details Does Not Exists!', 16, 1);
		END
END
GO
