USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderItemDetailsByPurchaseOrderId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdatePurchaseOrderItemDetailsByPurchaseOrderId]
	@PurchaseOrderId INT,
	@ItemName VARCHAR(30),
	@ItemId  INT,
	@purchaseOrderItemId INT,
	@Quantity DECIMAL,
	@ItemCost DECIMAL,
	@Discount DECIMAL,
	@Tax DECIMAL,
	@TotalCost DECIMAL,
	@UserId SMALLINT
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   IF EXISTS ( SELECT 1 FROM  [stk.PurchaseOrderItemsDraftDetails] WHERE Id = @purchaseOrderItemId)
      BEGIN
	  
	   UPDATE [stk.PurchaseOrderItemsDraftDetails] SET
	    
		Quantity =@Quantity,
		ItemCost = ItemCost,
		Discount = @Discount,
		Tax = @Tax,
		TotalCost = @TotalCost,
		LastModifiedUserId=@UserId	,
		LastModifiedDateTime = GETDATE()
	    WHERE Id =@purchaseOrderItemId
		SELECT * FROM  [stk.PurchaseOrderItemsDraftDetails] WHERE Id = @purchaseOrderItemId
	  END
  ELSE
      BEGIN
	    RAISERROR('This Product does not exists in this purchase order', 16, 1);
	  END

END
GO
