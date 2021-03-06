USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRequestItemsDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRequestItemsDetails]

	
AS
BEGIN
	SELECT 
	Br.BranchName,
	PORI.ProductId,
	PORI.ProductName,
	PORI.Quantity
	FROM [stk.PurchaseOrderRequestItems]PORI
	INNER JOIN [dbo].[stk.PurchaseOrderRequests] POR ON POR.PurchaseNo=PORI.PurchaseNo 
	INNER JOIN [dbo].[msd.Branch]Br ON Br.BranchId=POR.BranchId 
	
END
GO
