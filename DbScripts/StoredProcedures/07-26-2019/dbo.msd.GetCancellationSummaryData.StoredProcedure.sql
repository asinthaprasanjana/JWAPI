USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetCancellationSummaryData]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetCancellationSummaryData] 
(
	@cancellationTypeId SMALLINT,
	@id varchar(20)
)
AS
BEGIN

     IF(@cancellationTypeId = 1 ) --stock Transfer
	 BEGIN
		 SELECT STS.TransferId as id,
				STS.SourceLocationName as BillTo,
				STS.DestinationLocationName as ShipTo,
				AL.UserName,
				STS.CreatedDateTime

		 FROM [stk.StockTransferSummeryDetails] STS
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = STS.CreatedUserId
		 WHERE STS.Status = 0 AND STS.TransferId = @id
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
		 SELECT PO.PurchaseNo as id,
				AL.UserName,
				BP.DisplayName +' ' +'( ' + BP.BusinessPartnerId+  ' )' AS BusinessPartnerName ,
				PO.CreatedDateTime,
				PO.GrossTotal,
				PO.NetTotal,
				B2.BranchName as Billto,
				B3.BranchName as shipTo,
				PO.isCancelled


		 FROM [stk.PurchaseOrder] PO
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = PO.CreatedUserId
		INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
		INNER JOIN [msd.Branch] B2 ON B2.BranchId = PO.BillLocationId 
		INNER JOIN [msd.Branch] B3 ON B3.BranchId = PO.ShipLocationId 
		WHERE PO.PurchaseNo = @id
	 END

END 

GO
