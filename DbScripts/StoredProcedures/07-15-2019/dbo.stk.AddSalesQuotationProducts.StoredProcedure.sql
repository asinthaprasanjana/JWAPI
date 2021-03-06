USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesQuotationProducts]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSalesQuotationProducts]
	
(	
	@QuotationID VARCHAR(50),
	@ProductID INT,
	@Quantity INT,
	@UnitPrice FLOAT,
	@TotalCost FLOAT
)

AS
BEGIN
		DECLARE @LastQuotationId VARCHAR(20),
		        @ProductName     VARCHAR(50);


		SELECT @ProductName = P.ProductName FROM [msd_Product] P WHERE P.ProductId = @ProductID

		 
		INSERT INTO [stk.SalesQuotationProducts]
		(
			QuotationID,
			ProductID,
			ProductName,
			UnitPrice,
			Quantity,
			totalCost,
			CreatedDate
		) 
		values 
		( 
			
			@QuotationID ,
			@ProductID ,
			@ProductName,
			@UnitPrice ,
			@Quantity ,
			@TotalCost ,
			GETDATE()  
		)


	
END
GO
