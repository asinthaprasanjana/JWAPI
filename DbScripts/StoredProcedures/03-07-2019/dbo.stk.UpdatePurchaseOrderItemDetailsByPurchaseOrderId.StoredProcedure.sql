USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderItemDetailsByPurchaseOrderId]    Script Date: 07/03/2019 10:02:04 AM ******/
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
	@PurchaseOrderId int,
	@ItemName NVARCHAR(30),
	@ItemId  INT,
	@CompanyId INT,
	@purchaseOrderItemId INT,
	@Quantity int,
	@ItemCost money,
	@Discount money,
	@Tax money,
	@TotalCost money,
	@UserId int
	
	
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
