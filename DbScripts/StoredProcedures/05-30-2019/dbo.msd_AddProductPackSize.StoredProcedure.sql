USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd_AddProductPackSize]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd_AddProductPackSize]
	@PackSizeId INT OUTPUT,
	@ProductId INT,
	@PackSizeName VARCHAR(50),
	@PackQty DECIMAL(18,3),
	@CreatedUserId SMALLINT,
	@CompanyId INT
AS
BEGIN
		INSERT INTO [msd_ProductPackSize]
		(
			ProductId,
			PackSizeName,
			PackQty,
			CreatedUserId,
			CompanyId
		) 
		values 
		( 
			@ProductId,
			@PackSizeName,
			@PackQty,
			@CreatedUserId,
			@CompanyId	  
		)
		
		SET @PackSizeId= SCOPE_IDENTITY() 
		
		SELECT * FROM msd_ProductPackSize WHERE PackSizeId=@PackSizeId
END
GO
