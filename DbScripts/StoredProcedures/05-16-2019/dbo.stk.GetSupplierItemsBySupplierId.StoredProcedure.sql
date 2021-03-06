USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSupplierItemsBySupplierId]    Script Date: 16/05/2019 12:39:09 PM ******/
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
@ItemName   VARCHAR(20)
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS


	
	SELECT TOP 2000
	P.ProductId AS 'ItemId',
	(p.ProductName + ' - '+ '('+P.SKU+')') AS 'ItemName'
	FROM [dbo].[msd_Product] P
	WHERE P.ProductName LIKE '%'+ @ItemName+'%'
	--IF ( LEN( @ItemName)  >0)
	--     BEGIN
		
	--SELECT TOP 1000
	--P.Id_No AS 'ItemId',
	--(p.Prod_Name + ' - '+ '('+P.Prod_Code+')') AS 'ItemName',
	-- p.Selling_Price  AS 'SellingPrice'
	--FROM [Product] P
	--WHERE P.Prod_Name LIKE '%'+ @ItemName+'%'

	-- END
	

END
GO
