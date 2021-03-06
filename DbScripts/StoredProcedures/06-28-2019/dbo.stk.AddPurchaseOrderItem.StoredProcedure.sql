USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPurchaseOrderItem]    Script Date: 28/06/2019 4:49:03 PM ******/
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
	@ItemName Varchar(100),
	@Quantity INT,
	@purchaseOrderId INT,
	@ItemCost DECIMAL,
	@Discount DECIMAL,
	@Tax DECIMAL,
	@TotalCost DECIMAL,
	@PackSizeId INT,
	@UserId SMALLINT,
	@CompanyId SMALLINT

		
AS
BEGIN

    DECLARE @DraftStatus   INT = 0,
	        @LastPurchaseOrderId INT,
			@PackSizeName  VARCHAR(50),
	        @QuantityAfter INT =1 ;


		IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrderItemsDraftDetails]
		WHERE PurchaseNo = @purchaseOrderId AND ProductId = @productId AND ItemCost = @ItemCost )
          BEGIN
		   RETURN 0
		  END
		SELECT @PackSizeName = PackSizeName FROM [msd_ProductPackSize] WHERE PackSizeId = @PackSizeId

		INSERT INTO [stk.PurchaseOrderItemsDraftDetails]
		(	
		    CompanyId,
		    PurchaseNo,
			ProductId,
			ProductName,
			packSizeId,
			PackSizeName,
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
			@ItemName,
			@PackSizeId,
			@PackSizeName,
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
