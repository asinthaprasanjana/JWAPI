USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [msd].[test111]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [msd].[test111]
(
@ProductPriceLevelId INT,
@BranchId SMALLINT,
@ProductId INT,
@PackSizeId INT,
@Price1 DECIMAL(16,2),
@Price2 DECIMAL(16,2),
@Price3 DECIMAL(16,2),
@Price4 DECIMAL(16,2),
@Price5 DECIMAL(16,2),
@Price6 DECIMAL(16,2),
@Price7 DECIMAL(16,2),
@Price8 DECIMAL(16,2),
@Price9 DECIMAL(16,2),
@Price10 DECIMAL(16,2)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @PriceType SMALLINT,
	        @CreatedUserId SMALLINT ;

			SELECT @CreatedUserId = CreatedUserId
			FROM [msd.ProductPriceLevel] WHERE Id = @ProductPriceLevelId

	IF (@Price1>0)

	       
	    BEGIN


				  SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
				ORDER BY CategoryName
				 OFFSET ((1 - 1) * 1) ROWS
				 FETCH NEXT 1 ROWS ONLY;


				  INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price1,
				   @CreatedUserId,
				   GETDATE()
				   )
		END
	IF (@Price2>0)

	        
	    BEGIN

		  SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((2 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price2,
				   @CreatedUserId,
				   GETDATE()
				   )
		END

		IF (@Price3>0)

		   
	    BEGIN

		 SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((3 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;
              INSERT INTO [dbo].[msd.ProductPriceLevelItems]


			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price3,
				   @CreatedUserId,
				   GETDATE()
				   )
		END


		IF (@Price4>0)
		      
	    BEGIN

		     SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((4 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price4,
				   @CreatedUserId,
				   GETDATE()
				   )
		END

		IF (@Price5>0)
		      
			
	    BEGIN

		         SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((5 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price5,
				   @CreatedUserId,
				   GETDATE()
				   )
		END

		IF (@Price6>0)

		      
	    BEGIN

		      SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((6 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price6,
				   @CreatedUserId,
				   GETDATE()
				   )
		END

		IF (@Price7>0)

		     
	    BEGIN

		 SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((7 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price7,
				   @CreatedUserId,
				   GETDATE()
				   )
		END

		IF (@Price8>0)

		    
	    BEGIN
		        SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((8 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price8,
				   @CreatedUserId,
				   GETDATE()
				   )
		END

		IF (@Price9>0)
		         
	    BEGIN

		       SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
                  ORDER BY CategoryName
                  OFFSET ((9 - 1) * 1) ROWS
	              FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price9,
				   @CreatedUserId,
				   GETDATE()
				   )
		END


		IF (@Price10>0)

		      
	    BEGIN
		      SELECT  @PriceType = Id FROM [msd.PriceCategoryDetails]
              ORDER BY CategoryName
              OFFSET ((10 - 1) * 1) ROWS
	          FETCH NEXT 1 ROWS ONLY;


              INSERT INTO [dbo].[msd.ProductPriceLevelItems]
			   ([ProductPriceLevelId]
			   ,[BranchId]
			   ,[ProductId]
			   ,[PackSizeId]
			   ,[PriceType]
			   ,[Price]
			   ,[CreatedUserId]
			   ,[CreatedDateTime])
			 VALUES
				   (
				   @ProductPriceLevelId,
				   @BranchId,
				   @ProductId,
				   @PackSizeId,
				   @PriceType,
				   @Price10,
				   @CreatedUserId,
				   GETDATE()
				   )
		END
END
GO
