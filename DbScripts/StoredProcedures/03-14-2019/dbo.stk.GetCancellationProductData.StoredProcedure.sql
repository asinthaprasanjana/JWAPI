USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetCancellationProductData]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetCancellationProductData] 
(
	@typeId SMALLINT,
	@id varchar(20)
)
AS
BEGIN

     IF(@typeId = 0 ) --stock Transfer
	 BEGIN
		 SELECT STS.TransferId as id,
				STS.SourceLocationName as BillTo,
				STS.DestinationLocationName as ShipTo,
				AL.UserName,
				STS.CreatedDateTime

		 FROM [stk.StockTransferSummeryDetails] STS
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = STS.CreatedUserId
		 WHERE STS.Status = 0
	 END
    
	 IF(@typeId = 1 ) --Bill payment
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

	 IF(@typeId = 2 ) --purchase Order
	 BEGIN
		SELECT
				P.ProductName,
				POI.Quantity,
				POI.ItemCost,
				POI.Tax,
				POI.Discount,
				POI.TotalCost as netTotal

		 FROM [stk.PurchaseOrderItems] POI
		 INNER JOIN msd_Product P ON POI.ItemId = P.ProductId
		WHERE POI.PurchaseNo = @id
	 END

END 

GO
