USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecieveDetailsByDocumentNo]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecieveDetailsByDocumentNo]
	(
	  @DocumentNo VARCHAR(20)
	
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



	    
		      SELECT 
				PO.CompanyId,
				PO.RecievedId ,
				PO.PurchaseNo,
				PO.PurchaseOrderItemId,
				PO.ProductId,
				PO.TotalQuantity,
				PO.RecievedQuantity ,
				PO.FreeQuantity,
				Po.ProductName,
				PO.PackSizeName,
				POI.ItemCost,
				POI.TotalCost,
				AU.UserName	
				FROM [dbo].[stk.PurchaseOrderRecievedEvents] PO	INNER JOIN [stk.PurchaseOrderItems] POI ON POI.Id  = PO.PurchaseOrderItemId
				INNER JOIN  [msd.ApplicationUserLogInDetails] AU ON AU.UserID = PO.CreatedUserId
				WHERE PO.DocumentNo IN( SELECT * FROM dbo.splitstring(@DocumentNo))  AND PO.RecievedTypeId=3 
				Order By PO.PurchaseOrderItemId ASC;
		
	
	
END
GO
