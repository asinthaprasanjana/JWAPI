USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewSalesOrderInvoiceSummaryDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddNewSalesOrderInvoiceSummaryDetails]
(
@SaleNo VARCHAR(25),
@InvoiceType SMALLINT,
@CustomerId VARCHAR(25),
@CompanyId SMALLINT,
@InvoiceDate DATE,
@GrossTotal DECIMAL,
@NetTotal DECIMAL,
@TotalTax DECIMAL,
@TotalDiscounts DECIMAL,
@CreatedUserId SMALLINT
)
	
AS
BEGIN
			DECLARE @ApprovalStatus SMALLINT,
			@PaymentStatus          SMALLINT,
			@InvoiceNo				VARCHAR(25),
			@Id                     VARCHAR(25),
			@SalesOrderDocumentTypeId SMALLINT = 11

			SET @ApprovalStatus = 0
			SET @PaymentStatus = 0


				EXEC	 [dbo].[stk.GetDocumentIdByDocumentTypeId] @SalesOrderDocumentTypeId, @Id OUTPUT
			     SET @InvoiceNo = @Id
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
