USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetPurchaseOrderBillDetailsByPurchaseNo]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetPurchaseOrderBillDetailsByPurchaseNo]
	(
	   @PurchaseNo VARCHAR(20) 
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT 
	B.BillId As Id,
	B.BilledPrice AS ItemCost,
	B.BilledQuantity AS Quantity ,
	B.PurchaseOrderNo AS PurchaseNo,
	B.BillId AS Id,
	B.ProductId,
	P.ProductName,
	AUL.UserName,
	CASE POB.PaymentStatus
	         WHEN 0 THEN 'Pending'
             WHEN 1 THEN 'Paid'
             WHEN 2 THEN 'Partially Paid'
          END  AS 'PaymentStatus',
	CONVERT(varchar, B.CreatedDateTime, 100) AS CreatedDateTime
	FROM [csh.PurchaseOrderBilledEvents] B
	INNER JOIN [msd_Product] P ON P.ProductId = B.ProductId
	INNER JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = B.CreatedUserId
	INNER JOIN [csh.PurchaseOrderBilled] POB ON POB.Id = B.BillId
	WHERE B.PurchaseOrderNo = @PurchaseNo
END
GO
