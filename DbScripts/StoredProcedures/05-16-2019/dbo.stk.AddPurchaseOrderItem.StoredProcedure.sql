USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPurchaseOrderItem]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPurchaseOrderItem]
	@productId INT,
	@ItemName Varchar(50),
	@Quantity INT,
	@purchaseOrderId INT,
	@ItemCost money,
	@Discount money,
	@Tax money,
	@TotalCost money,
	@PackSizeId INT,
	@UserId SMALLINT,
	@CompanyId SMALLINT

		
AS
BEGIN

    DECLARE @DraftStatus   INT = 0,
	        @LastPurchaseOrderId INT,
	        @QuantityAfter INT =1 ;

		IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrderItemsDraftDetails]
		WHERE PurchaseNo = @purchaseOrderId AND ItemId = @productId AND ItemCost = @ItemCost )
          BEGIN
		   RETURN 0
		  END
		INSERT INTO [stk.PurchaseOrderItemsDraftDetails]
		(	
		    CompanyId,
		    PurchaseNo,
			ItemId,
			packSizeId,
			Quantity,
			QuantityAfter,
			Status,
			ItemCost,
			Discount,
			Tax,
			TotalCost,
			CreatedUserId,
			CreatedDateTime
		) 
		values ( 
		    @CompanyId,
		    @purchaseOrderId,
			@productId ,
			@PackSizeId,
			@Quantity ,
			@QuantityAfter,
			@DraftStatus,
			@ItemCost ,
			@Discount ,
			@Tax ,
			@TotalCost,
			@UserId ,
			GETDATE()	  
		)

		SELECT @LastPurchaseOrderId= SCOPE_IDENTITY() 
		SELECT @LastPurchaseOrderId AS purchaseOrderItemId
		
 
END
GO
