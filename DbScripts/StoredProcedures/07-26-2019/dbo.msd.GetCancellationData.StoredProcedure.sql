USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetCancellationData]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetCancellationData] 
(
	@cancellationTypeId SMALLINT
)
AS
BEGIN

     IF(@cancellationTypeId = 1 ) --stock Transfer
	 BEGIN
		 SELECT STS.TransferId as id,
				STS.SourceLocationName as BillTo,
				STS.DestinationLocationName as ShipTo,
				AL.UserName,
				 CONVERT(VARCHAR(10), STS.[CreatedDateTime], 110)  AS 'CreatedDateTime'

		 FROM [stk.StockTransferSummeryDetails] STS
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = STS.CreatedUserId
		 WHERE STS.isCancelled = 1
	 END
    
	 IF(@cancellationTypeId = 2 ) --Bill payment
	 BEGIN
		 SELECT POB.id as id,
				POB.PurchaseOrderNo,
				AL.UserName,
				POB.TotalPrice as netTotal,
				POB.BillDate,
				 CONVERT(VARCHAR(10), POB.[CreatedDateTime], 110)  AS 'CreatedDateTime'

		 FROM [csh.PurchaseOrderBilled] POB
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = POB.CreatedUserId
	 END

	 IF(@cancellationTypeId = 3 ) --purchase Order
	 BEGIN
		 SELECT PO.PurchaseNo as id,
				AL.UserName,
				BP.DisplayName as businessPartnerName,
				PO.GrossTotal,
				PO.NetTotal,
				B2.BranchName as Billto,
				B3.BranchName as shipTo,
				CONVERT(VARCHAR(10), PO.[CreatedDateTime], 110)  AS 'CreatedDateTime'

		 FROM [stk.PurchaseOrder] PO
			INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = PO.CreatedUserId
			INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
			INNER JOIN [msd.Branch] B2 ON B2.BranchId = PO.BillLocationId 
			INNER JOIN [msd.Branch] B3 ON B3.BranchId = PO.ShipLocationId 
			WHERE PO.isCancelled = 1
	 END

END 

GO
