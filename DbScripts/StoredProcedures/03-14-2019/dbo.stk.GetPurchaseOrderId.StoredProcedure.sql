USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderId]
	@CompanyID INT
AS
BEGIN
	Select TOP 1 *
	FROM [stk.PurchaseOrder] PO
	WHERE PO.CompanyId = @CompanyID
	ORDER by PO.Id DESC 

END
GO
