USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderDraftDetailsByPurchaseOrderId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderDraftDetailsByPurchaseOrderId]
(
@PurchaseOrderId INT,
@CompanyId INT
)
AS
BEGIN

	SELECT TOP 1 *
	FROM [stk.PurchaseOrderDraftDetails] PO
	WHERE PO.CompanyId= @CompanyID AND PO.PurchaseNo = @PurchaseOrderId
	
END
GO
