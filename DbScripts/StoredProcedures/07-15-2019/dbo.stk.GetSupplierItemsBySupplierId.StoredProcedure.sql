USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSupplierItemsBySupplierId]    Script Date: 15/07/2019 12:10:19 PM ******/
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
@SupplierId SMALLINT,
@ItemName   VARCHAR(20)
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	 SELECT 
			P.ProductId AS 'ItemId',
			--P.SKU,
			(p.ProductName + ' - '+ '('+P.SKU+')') AS 'ItemName'
			FROM [dbo].[msd_Product] P
			WHERE P.ProductName LIKE  @ItemName+'%'


	--IF EXISTS( SELECT 1 FROM [msd_Product] P WHERE p.ProductName LIKE '%'+ @ItemName+'%'  )
	--  BEGIN
	--       SELECT 
	--		P.ProductId AS 'ItemId',
	--		--P.SKU,
	--		(p.ProductName + ' - '+ '('+P.SKU+')') AS 'ItemName'
	--		FROM [dbo].[msd_Product] P
	--		WHERE P.ProductName LIKE '%'+ @ItemName+'%'
	--  END
	--ELSE
	--  BEGIN
	--     SELECT 
	--	 P.ProductId AS 'ItemId',
	--	-- P.SKU,
	--     (p.ProductName + ' - '+ '('+P.SKU+')') AS 'ItemName'
	--     FROM [dbo].[msd_Product] P
	--     WHERE P.SKU LIKE '%'+ @ItemName+'%'
	--  END
	
	

END
GO
