USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderBilledEventsDetailsByBusinessPartnerId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderBilledEventsDetailsByBusinessPartnerId]
(
@BusinessPartnerId varchar(50)
)
AS
BEGIN
	Select *
	FROM [dbo].[stk.PurchaseOrderBilledEvents] PBE
	INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = PBE.PurchaseOrderNo
	WHERE PO.SupplierId = @BusinessPartnerId



END
GO
