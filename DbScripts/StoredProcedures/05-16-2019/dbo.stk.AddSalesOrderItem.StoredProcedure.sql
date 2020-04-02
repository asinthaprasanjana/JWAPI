USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesOrderItem]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSalesOrderItem]
	@ItemId INT,
	@ItemName Varchar(50),
	@Quantity INT,
	@salesOrderId INT,
	@salesOrderItemId INT,
	@ItemCost money,
	@Discount money,
	@Tax money,
	@TotalCost money,
	@UserId SMALLINT,
	@CompanyId INT

		
AS
BEGIN

    DECLARE @DraftStatus   INT = 0,
	        @LastSalesOrderId INT

		INSERT INTO [stk.SalesOrderItemsDraftDetails]
		(	
		    CompanyId,
		    SaleNo,
			ItemId,
			Quantity,
			Status,
			ItemCost,
			Discount,
			Tax,
			TotalCost,
			CreatedUserId,
			CreatedDateTime,
			LastModifiedDateTime
		) 
		values ( 
		    @CompanyId,
		    @salesOrderId,
			@ItemId ,
			@Quantity ,
			@DraftStatus,
			@ItemCost ,
			@Discount ,
			@Tax ,
			@TotalCost,
			@UserId ,
			GETDATE(),
			GETDATE()		  
		)

		SELECT @LastSalesOrderId= SCOPE_IDENTITY() 

		SELECT SaleNo , ItemId AS salesOrderItemId
		FROM [stk.SalesOrderItemsDraftDetails]
		WHERE Id=@LastSalesOrderId
		
 
END
GO
