USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetCancellationProductData]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetCancellationProductData] 
(
	@cancellationTypeId SMALLINT,
	@id varchar(20)
)
AS
BEGIN

     IF(@cancellationTypeId = 1 ) --stock Transfer
	 BEGIN
		 SELECT STI.TransferId as id,
				P.ProductName as productName,
				STI.Quantity
		 FROM [stk.StockTransfersItem] STI
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = STI.CreatedUserId
		 INNER JOIN [msd_Product] P ON P.ProductId = STI.ItemId
		 WHERE STI.TransferId = @id
	 END
    
	 IF(@cancellationTypeId = 2 ) --Bill payment
	 BEGIN
		 SELECT BP.BillPaymentId as id,
				AL.UserName,
				BP.TotalPrice as netTotal,
				B.DisplayName as businessPartnerName,
				BP.CreatedDateTime

		 FROM [csh.BillPayment] BP
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = BP.CreatedUserId
		 INNER JOIN [bsp.BusinessPartner] B ON B.BusinessPartnerId = BP.BusinessPartnerId
		 WHERE BP.BillPaymentId = @id
	 END

	 IF(@cancellationTypeId = 3 ) --purchase Order
	 BEGIN
		SELECT
				P.ProductName,
				POI.Quantity,
				POI.ItemCost as unitPrice,
				POI.Tax,
				POI.Discount,
				POI.TotalCost as totalCost

		 FROM [stk.PurchaseOrderItems] POI
		 INNER JOIN msd_Product P ON POI.ItemId = P.ProductId
		 WHERE POI.PurchaseNo = @id
	 END

END 

GO
