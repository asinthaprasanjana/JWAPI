USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSupplierItem]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CReate PROCEDURE [dbo].[stk.GetSupplierItem]
	@BusinessPartnerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT 
		SI.Id,
		SI.ItemId,
		SI.ItemName
	FROM dbo.[stk.SupplierItems] SI
	WHERE SI.BusinessPartnerId =@BusinessPartnerId
	
END
GO
