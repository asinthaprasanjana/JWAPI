USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewSalesOrderInvoiceSummaryDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewSalesOrderInvoiceSummaryDetails]
(
@InvoiceNo VARCHAR(25),
@SaleNo VARCHAR(25),
@InvoiceType SMALLINT,
@CustomerId VARCHAR(25),
@CompanyId INT,
@InvoiceDate DATE,
@GrossTotal DECIMAL,
@NetTotal DECIMAL,
@TotalTax DECIMAL,
@TotalDiscounts DECIMAL,
@CreatedUserId SMALLINT
)
	
AS
BEGIN
	DECLARE @ApprovalStatus smallint, @PaymentStatus smallint
	SET @ApprovalStatus = 0
	SET @PaymentStatus = 0
 INSERT INTO [csh.SalesOrderInvoiced]
 (
	[InvoiceNo],
	[SaleNo],
	[InvoiceType],
	[InvoiceDate],
	[CustomerId],
	[GrossTotal],
	[NetTotal],
	[TotalTax],
	[TotalDiscounts],
	[ApprovalStatus],
	[PaymentStatus],
	[CompanyId],
	[CreatedUserId],
	[CreatedDateTime]

 )

 VALUES
 (
	@InvoiceNo,
	@SaleNo,
	@InvoiceType,
	@InvoiceDate,
	@CustomerId,
	@GrossTotal,
	@NetTotal,
	@TotalTax,
	@TotalDiscounts,
	@ApprovalStatus,
	@PaymentStatus,
	@CompanyId,
	@CreatedUserId,
	GETDATE()
 )

 IF(@SaleNo != '')
 BEGIN
	UPDATE [stk.SalesOrder] 
	SET Invoiced=1
	WHERE SaleNo=@SaleNo
 END
		
END


GO
