USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSupplierItemsByItemId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
Create PROCEDURE [dbo].[stk.GetSupplierItemsByItemId]
(

 @ItemId INT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		SELECT 
			SI.Id,
			SI.ItemName,
			SI.BusinessPartnerId,
			SI.CreatedUserId,
			SI.CreatedDateTime
		FROM [stk.SupplierItems] SI
	WHERE  SI.ItemId= @ItemId
END 
GO
