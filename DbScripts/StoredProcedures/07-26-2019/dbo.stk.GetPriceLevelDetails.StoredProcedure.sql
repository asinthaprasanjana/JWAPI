USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPriceLevelDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPriceLevelDetails]
(
@UserId SMALLINT,
@ProductPriceLevelId INT,
@ProductId INT,
@BranchId    SMALLINT
)	
AS
BEGIN


-- Important Note : Do not Change the order by clause

IF ( @ProductPriceLevelId> 0  )
   BEGIN

        SELECT 
		 L.PriceLevelName,
		 P.ProductId,
		 PL.BranchId,
		 B.BranchName,
		 P.ProductName,
		 PP.PackSizeId,
		 PP.PackSizeName,
		 PL.PriceType AS 'PriceTypeId',
		 PC.Id,
		 PC.CategoryName AS 'PriceType',
		 PL.Price
		 FROM [msd.ProductPriceLevelItems] PL
		 INNER JOIN [msd.Branch] B ON B.BranchId = PL.BranchId
		 INNER JOIN [msd.ProductPriceLevel] L ON L.Id = PL.ProductPriceLevelId
		 INNER JOIN [msd_Product] P ON P.ProductId = PL.ProductId
		 INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = PL.PackSizeId
		 INNER JOIN [msd.PriceCategoryDetails] PC ON PC.Id = PL.PriceType
		WHERE PL.ProductPriceLevelId = @ProductPriceLevelId  AND PL.BranchId = @BranchId
		ORDER BY PP.PackSizeId , PC.CategoryName ASC
   END
ELSE
  BEGIN

       DECLARE @LastPriceLevelId INT ;

	   SELECT TOP 1 @LastPriceLevelId = Id
	   FROM [msd.ProductPriceLevel] 
	   WHERE ProductId = @ProductId ORDER BY CreatedDateTime DESC

	   SELECT 
	     PL.ProductPriceLevelId,
		 L.PriceLevelName,
		 P.ProductId,
		 PL.BranchId,
		 B.BranchName,
		 P.ProductName,
		 PP.PackSizeId,
		 PP.PackSizeName,		 
		 PC.Id,
		 PC.CategoryName AS 'PriceType',
		 PL.Price,
		 PC.CategoryName
		 FROM [msd.ProductPriceLevelItems] PL
		 INNER JOIN [msd.Branch] B ON B.BranchId = PL.BranchId
		 INNER JOIN [msd.ProductPriceLevel] L ON L.Id = PL.ProductPriceLevelId
		 INNER JOIN [msd_Product] P ON P.ProductId = PL.ProductId
		 INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = PL.PackSizeId
		 INNER JOIN [msd.PriceCategoryDetails] PC ON PC.Id = PL.PriceType
		WHERE PL.BranchId = @BranchId AND PL.ProductId = @ProductId
		AND PL.ProductPriceLevelId IN ( SELECT TOP 1 Id
	   FROM [msd.ProductPriceLevel] 
	   WHERE ProductId = @ProductId ORDER BY CreatedDateTime DESC)
		ORDER BY PP.PackSizeId , PC.CategoryName ASC
  END
	
END
GO
