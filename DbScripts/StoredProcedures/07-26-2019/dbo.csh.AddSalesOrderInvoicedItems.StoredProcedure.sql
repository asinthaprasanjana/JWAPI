USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddSalesOrderInvoicedItems]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.AddSalesOrderInvoicedItems]
	@ProductId INT,
	@Quantity INT,
	@PackSizeId SMALLINT,
	@InvoiceNo VARCHAR (25),
	@ItemCost DECIMAL,
	@Discount DECIMAL,
	@Tax DECIMAL,
	@UserId SMALLINT,
	@CompanyId INT

		
AS
BEGIN


		INSERT INTO [csh.SalesOrderInvoicedItems]
		(	
		   CompanyId,
		   InvoiceNo,
		   ProductId,
		   Quantity,
		   PackSizeId,
		   ItemCost,
		   Discount,
		   Tax,
		   CreatedUserId,
		   CreatedDateTime
		) 
		values ( 
		    @CompanyId,
		    @InvoiceNo,
			@ProductId ,
			@Quantity ,
			@PackSizeId,
			@ItemCost ,
			@Discount ,
			@Tax ,
			@UserId ,
			GETDATE()		  
		)
END
GO
