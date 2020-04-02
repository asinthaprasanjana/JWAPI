USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSupplierItemsBySupplierId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSupplierItemsBySupplierId]
(
@SupplierId INT,
@ItemName   NVARCHAR(20)
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS


	
	SELECT 
	P.ProductId AS 'ItemId',
	(p.ProductName + ' - '+ '('+P.SKU+')') AS 'ItemName'
	FROM [dbo].[msd_Product] P
	WHERE P.ProductName LIKE '%'+ @ItemName+'%'
	

END
GO
