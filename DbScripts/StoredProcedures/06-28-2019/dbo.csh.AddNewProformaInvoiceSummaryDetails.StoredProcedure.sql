USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewProformaInvoiceSummaryDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewProformaInvoiceSummaryDetails]
(
@InvoiceNo VARCHAR(25),
@SaleNo VARCHAR(25),
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
 INSERT INTO [csh.ProformaInvoice]
 (
	[InvoiceNo],
	[SaleNo],
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
	SET Invoiced=5
	WHERE SaleNo=@SaleNo
 END
		
END


GO
