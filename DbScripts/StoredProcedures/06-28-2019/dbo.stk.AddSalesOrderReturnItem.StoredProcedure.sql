USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesOrderReturnItem]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pasindu Sanjana>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSalesOrderReturnItem]
	@ItemId INT,
	@ReturningQuantity INT,
	@SalesOrderReturnId INT,
	@ReturningPrice DECIMAL,
	@UserId SMALLINT,
	@CompanyId SMALLINT

		
AS
BEGIN

         DECLARE @ProductName VARCHAR(100);

		SELECT @ProductName = P.ProductName FROM [msd_Product] P WHERE P.ProductId = @ItemId


		INSERT INTO [stk.SalesOrderReturnItems]
		(	
		    CompanyId,
			SaleOrderReturnId,
			ProductId,
			ProductName,
			ReturningQuantity,
			ReturningPrice,
			CreatedUserId,
			CreatedDateTime
		) 
		values ( 
		    @CompanyId,
			@SalesOrderReturnId,
			@ItemId ,
			@ProductName,
			@ReturningQuantity ,
			@ReturningPrice,
			@UserId ,
			GETDATE()	 
		)

 
END
GO
