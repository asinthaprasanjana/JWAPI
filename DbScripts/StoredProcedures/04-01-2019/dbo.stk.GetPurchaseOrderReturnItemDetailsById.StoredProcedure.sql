USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderReturnItemDetailsById]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderReturnItemDetailsById]
(
@PurchaseOrderReturnId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT 
	PORI.Id,
	P.ProductName,
	PORI.ReturningPrice,
	PORI.ReturningQuantity,
	PORI.Reason,
	PORI.CreatedDateTime
	
	From  [dbo].[stk.PurchaseOrderReturnItems] PORI
	INNER JOIN [msd_Product] P ON P.ProductId =PORI.ProductId
	WHERE  PORI.PurchaseOrderReturnId = @PurchaseOrderReturnId
	
END
GO
