USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetGatePassItemsDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetGatePassItemsDetails]
(
@DocumentNumber VARCHAR(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT 
	  GI.DocumentNumber,
	  GI.GatePassDetailsID,
	  GI.ProductId,
	  GI.ProductName,
	  GI.Quantity,
	  GI.PackSizeId,
	  GI.PackSizeName,
	  GI.ReturnDate,
	  GI.Reason
	FROM [dbo].[stk.GatePassItems] GI
END
GO
