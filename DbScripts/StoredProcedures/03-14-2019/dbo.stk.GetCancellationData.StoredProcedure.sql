USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetCancellationData]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetCancellationData] 
(
	@typeId SMALLINT
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
	 END

	 IF(@typeId = 2 ) --purchase Order
	 BEGIN
		 SELECT PO.PurchaseNo as id,
				AL.UserName,
				BP.DisplayName as businessPartnerName,
				PO.CreatedDateTime,
				PO.GrossTotal,
				PO.NetTotal,
				B2.BranchName as Billto,
				B3.BranchName as shipTo

		 FROM [stk.PurchaseOrder] PO
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = PO.CreatedUserId
		INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
		INNER JOIN [msd.Branch] B2 ON B2.BranchId = PO.BillLocationId 
		INNER JOIN [msd.Branch] B3 ON B3.BranchId = PO.ShipLocationId 
	 END

END 

GO
