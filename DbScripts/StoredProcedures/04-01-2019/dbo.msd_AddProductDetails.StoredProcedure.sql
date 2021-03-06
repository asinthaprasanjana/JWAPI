USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd_AddProductDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd_AddProductDetails]
	@ProductId INT OUTPUT,
	@ProductGroupId INT,
	@ProductName VARCHAR(300),
	@Sku VARCHAR(30),
	@ShortDescription VARCHAR(100),
	@ProductDescription VARCHAR(500),
	@ProductType VARCHAR(15),
	@IsTradingProduct BIT,
	@CostingMethod VARCHAR(15),
	@IncomeAccountId INT,
	@CogsAccountId INT,
	@AssestsAccountId INT,
	@ReorderLevel DECIMAL(18,3),
	@ReorderQty DECIMAL(18,3),
	@UnitOfMeasure VARCHAR(10),
	@CreatedUserId INT,
	@CompanyId INT,
	@PackSize VARCHAR(MAX)
AS
BEGIN
		INSERT INTO [msd_Product]
		(
			ProductGroupId,
			ProductName,
			Sku,
			ShortDescription,
			ProductDescription,
			ProductType,
			IsTradingProduct,
			CostingMethod,
			IncomeAccountId,
			CogsAccountId,
			AssestsAccountId,
			ReorderLevel,
			ReorderQty,
			UnitOfMeasure,
			CreatedUserId,
			CompanyId
		) 
		values 
		( 
			@ProductGroupId,
			@ProductName,
			@Sku,
			@ShortDescription,
			@ProductDescription,
			@ProductType,
			@IsTradingProduct,
			@CostingMethod,
			@IncomeAccountId,
			@CogsAccountId,
			@AssestsAccountId,
			@ReorderLevel,
			@ReorderQty,
			@UnitOfMeasure,
			@CreatedUserId,
			@CompanyId	  
		)
		
		SET @ProductId= SCOPE_IDENTITY() 
		
		SELECT * FROM msd_Product WHERE ProductId=@ProductId
END
GO
