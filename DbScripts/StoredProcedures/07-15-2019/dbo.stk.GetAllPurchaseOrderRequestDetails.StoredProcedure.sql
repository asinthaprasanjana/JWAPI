USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllPurchaseOrderRequestDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllPurchaseOrderRequestDetails]
(
  @PageId INT
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	POR.BranchId,
	POR.Id,
	POR.CreatedUserId,
	POR.Remarks
	FROM [stk.PurchaseOrderRequests]  POR
END
GO
