USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllPurchaseOrderBillDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllPurchaseOrderBillDetails]
(
	@CompanyId INT
)
AS
BEGIN
	Select  *
	FROM [stk.PurchaseOrderBilled]
	WHERE CompanyId = @CompanyId


END
GO
