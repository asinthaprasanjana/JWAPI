USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesOrderReturnItem]    Script Date: 01/04/2019 9:46:08 AM ******/
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
	@ReturningPrice money,
	@UserId SMALLINT,
	@CompanyId INT

		
AS
BEGIN


		INSERT INTO [stk.SalesOrderReturnItems]
		(	
		    CompanyId,
			SaleOrderReturnId,
			ProductId,
			ReturningQuantity,
			ReturningPrice,
			CreatedUserId,
			CreatedDateTime
		) 
		values ( 
		    @CompanyId,
			@SalesOrderReturnId,
			@ItemId ,
			@ReturningQuantity ,
			@ReturningPrice,
			@UserId ,
			GETDATE()	 
		)

 
END
GO
