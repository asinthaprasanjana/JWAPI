USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd_AddProductDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
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
	@ProductGroupId VARCHAR (20),
	@ProductName VARCHAR(300),
	@LevelId01 SMALLINT,
	@LevelId02 SMALLINT,
	@LevelId03 SMALLINT,
	@LevelId04 SMALLINT,
	@LevelId05 SMALLINT,
	@Sku VARCHAR(30),
	@ShortDescription VARCHAR(100),
	@ProductDescription VARCHAR(500),
	@ProductType VARCHAR(15),
	@IsTradingProduct BIT,
	@CostingMethod VARCHAR(15),
	@IncomeAccountId INT,
	@CogsAccountId INT,
	@AssestsAccountId INT,
	@ReorderLevel DECIMAL,
	@ReorderQty DECIMAL,
	@UnitOfMeasure VARCHAR(10),
	@CreatedUserId SMALLINT,
	@CompanyId INT
AS
BEGIN
		INSERT INTO [msd_Product]
		(
			
			ProductName,
			LevelId01,
			LevelId02,
			LevelId03,
			LevelId04,
			LevelId05,
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
			@ProductName,
			@LevelId01,
			@LevelId02,
			@LevelId03,
			@LevelId04,
			@LevelId05,
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
