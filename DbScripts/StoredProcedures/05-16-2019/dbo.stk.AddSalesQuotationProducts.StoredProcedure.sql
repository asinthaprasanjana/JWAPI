USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesQuotationProducts]    Script Date: 16/05/2019 12:39:09 PM ******/
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
		DeCLARE @LastQuotationId VARCHAR(20)
		 
		INSERT INTO [stk.SalesQuotationProducts]
		(
			QuotationID,
			ProductID,
			UnitPrice,
			Quantity,
			totalCost,
			CreatedDate
		) 
		values 
		( 
			
			@QuotationID ,
			@ProductID ,
			@UnitPrice ,
			@Quantity ,
			@TotalCost ,
			GETDATE()  
		)

	
END
GO
