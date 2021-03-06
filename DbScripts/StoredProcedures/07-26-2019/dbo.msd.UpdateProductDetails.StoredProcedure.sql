USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateProductDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateProductDetails]
(
@ProductId INT,
@ProductGroupId INT
,@ProductName VARCHAR(300)
,@SKU VARCHAR(50)
,@ShortDescription VARCHAR(100)
,@ProductDescription VARCHAR(500)
,@ProductType VARCHAR(15)
,@IsTradingProduct BIT
,@CostingMethod VARCHAR(15)
,@IncomeAccountId INT
,@CogsAccountId INT
,@AssestsAccountId INT
,@ReorderLevel DECIMAL(18,3)
,@ReorderQty DECIMAL(18,3)
,@UnitOfMeasure VARCHAR(10)
,@CreatedUserId SMALLINT
,@CompanyId  INT

)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[msd_Product]
   SET 
   --[ProductGroupId] = @ProductGroupId
      [ProductName] = @ProductName
      ,[SKU] = @SKU
      ,[ShortDescription] = @ShortDescription
      ,[ProductDescription] = @ProductDescription
      ,[ProductType] = @ProductType
      ,[IsTradingProduct] = @IsTradingProduct
      ,[CostingMethod] = @CostingMethod
      ,[IncomeAccountId] = @IncomeAccountId
      ,[CogsAccountId] =@CogsAccountId
      ,[AssestsAccountId] = @AssestsAccountId
      ,[ReorderLevel] = @ReorderLevel
      ,[ReorderQty] = @ReorderQty
      ,[UnitOfMeasure] = @UnitOfMeasure
      ,[CreatedUserId] = @CreatedUserId
      ,[CompanyId] = @CompanyId
      ,[CreatedDate] = GETDATE()
      
	WHERE  ProductId = @ProductId
END 
GO
