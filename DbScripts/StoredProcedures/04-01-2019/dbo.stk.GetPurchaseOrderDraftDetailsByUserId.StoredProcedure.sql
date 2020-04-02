USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderDraftDetailsByUserId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderDraftDetailsByUserId]
(
@UserId INT
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS
	
	SELECT * FROM [stk.PurchaseOrderItemsDraftDetails] POIDD WHERE  POIDD.CreatedUserId = @UserId

END
GO
