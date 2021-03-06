USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderItemDetailsByPurchaseOrderId]    Script Date: 16/05/2019 12:39:09 PM ******/
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
	@CompanyId INT,
	@purchaseOrderItemId INT,
	@Quantity INT,
	@ItemCost MONEY,
	@Discount MONEY,
	@Tax MONEY,
	@TotalCost MONEY,
	@UserId INT
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM  [stk.PurchaseOrderItemsDraftDetails] WHERE Id = @purchaseOrderItemId
	UPDATE [stk.PurchaseOrderItemsDraftDetails] SET
	    
		Quantity =@Quantity,
		ItemCost = ItemCost,
		Discount = @Discount,
		Tax = @Tax,
		TotalCost = @TotalCost,
		CreatedUserId=@UserId	
	    WHERE Id =@purchaseOrderItemId
	
		SELECT * FROM  [stk.PurchaseOrderItemsDraftDetails] WHERE Id = @purchaseOrderItemId

END
GO
